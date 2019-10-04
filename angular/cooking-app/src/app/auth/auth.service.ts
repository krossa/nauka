import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { throwError, BehaviorSubject } from 'rxjs';
import { User } from './user.model';
import { Router } from '@angular/router';

export interface AuthResponseData {
    idToken: string;
    email: string;
    refreshToken: string;
    expiresIn: string;
    localId: string;
    registered?: boolean;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
    user = new BehaviorSubject<User>(null);
    private tokenExpirationTimer: any;

    constructor(private http: HttpClient, private router: Router) { }

    login(email: string, password: string) {
        return this.http.post<AuthResponseData>(
            'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBZfCV-9Gdikiqw2IHltWEk5FtdOuiWesc',
            {
                email,
                password,
                returnSecureToken: true
            }
        ).pipe(
            catchError(this.handleError),
            tap(this.handleAuthentication.bind(this))

        );
    }

    autoLogin() {
        const userData: {
            email: string,
            id: string,
            _token: string,
            _tokenExpirationDate: string
        } = JSON.parse(localStorage.getItem('userData'));
        if (!userData) {
            return;
        }

        const loadedUser = new User(userData.email, userData.id, userData._token, new Date(userData._tokenExpirationDate));
        console.log(loadedUser);
        if (loadedUser.token) {
            this.autoLogout(new Date(userData._tokenExpirationDate).getTime() - new Date().getTime());
            this.user.next(loadedUser);
        }
    }

    signup(email: string, password: string) {
        return this.http.post<AuthResponseData>(
            'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyBZfCV-9Gdikiqw2IHltWEk5FtdOuiWesc',
            {
                email,
                password,
                returnSecureToken: true
            }
        ).pipe(
            catchError(this.handleError),
            tap(data => this.handleAuthentication(data))
        );
    }

    logout() {
        this.user.next(null);
        this.router.navigate(['/auth']);
        localStorage.removeItem('userData');
        if (this.tokenExpirationTimer) {
            clearTimeout(this.tokenExpirationTimer);
        }

        this.tokenExpirationTimer = null;
    }

    autoLogout(expirationDuration: number) {
        this.tokenExpirationTimer = setTimeout(() => {
            this.logout();
        }, expirationDuration);
    }

    private handleAuthentication(data: AuthResponseData) {
        const expirationDate = new Date(new Date().getTime() + +data.expiresIn * 1000);
        const user = new User(data.email, data.localId, data.idToken, expirationDate);
        this.user.next(user);
        this.autoLogout(+data.expiresIn * 1000);
        localStorage.setItem('userData', JSON.stringify(user));
    }

    private handleError(errResp: HttpErrorResponse) {
        let message = 'An Error';
        if (!errResp.error || !errResp.error.error) {
            return throwError(message);
        }
        switch (errResp.error.error.message) {
            case 'EMAIL_EXISTS':
                message = 'This email exists already';
                break;
            case 'EMAIL_NOT_FOUND':
                message = 'Email not found';
                break;
            case 'INVALID_PASSWORD':
                message = 'Invalid password';
        }
        return throwError(message);
    }
}
