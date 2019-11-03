import { Actions, ofType, Effect } from '@ngrx/effects';
import { switchMap, catchError, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { Injectable } from '@angular/core';

import { environment } from '../../../environments/environment';
import * as AuthActions from './auth.actions';
import { Router } from '@angular/router';
import { User } from '../user.model';
import { AuthService } from '../auth.service';

export interface AuthResponseData {
  idToken: string;
  email: string;
  refreshToken: string;
  expiresIn: string;
  localId: string;
  registered?: boolean;
}

const handleAuthentication = (expiresIn: number, email: string, userId: string, token: string) => {
  const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
  const user = new User(email, userId, token, expirationDate);
  localStorage.setItem('userData', JSON.stringify(user));
  return new AuthActions.AuthenticateSuccess(
    {
      email,
      userId,
      token,
      expirationDate
    });
};

const handleError = (errResp: any) => {
  let message = 'An Error';
  if (!errResp.error || !errResp.error.error) {
    return of(new AuthActions.AuthenticateFail(message));
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
  return of(new AuthActions.AuthenticateFail(message));
};

@Injectable()
export class AuthEffects {

  @Effect()
  authSignup = this.actions$.pipe(
    ofType(AuthActions.SIGNUP_START),
    switchMap((signupAction: AuthActions.SignupStart) => {
      return this.http.post<AuthResponseData>(
        'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=' + environment.firebaseAPIKey,
        {
          email: signupAction.payload.email,
          password: signupAction.payload.password,
          returnSecureToken: true
        }
      ).pipe(
        tap(resData => {
          this.authService.setLogoutTimer(+resData.expiresIn * 1000);
        }),
        map(resData => {
          return handleAuthentication(+resData.expiresIn, resData.email, resData.localId, resData.idToken);
        }),
        catchError(errResp => {
          return handleError(errResp);
        })
      );
    })
  );

  @Effect()
  authLogin = this.actions$.pipe(
    ofType(AuthActions.LOGIN_START),
    switchMap((authData: AuthActions.LoginStart) => {
      return this.http.post<AuthResponseData>(
        'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=' + environment.firebaseAPIKey,
        {
          email: authData.payload.email,
          password: authData.payload.password,
          returnSecureToken: true
        }
      ).pipe(
        tap(resData => {
          this.authService.setLogoutTimer(+resData.expiresIn * 1000);
        }),
        map(resData => {
          return handleAuthentication(+resData.expiresIn, resData.email, resData.localId, resData.idToken);
        }),
        catchError(errResp => {
          return handleError(errResp);
        })
      );
    }),
  );

  @Effect({ dispatch: false })
  authLogout = this.actions$.pipe(
    ofType(AuthActions.LOGOUT),
    tap(() => {
      this.router.navigate(['/auth']);
      localStorage.removeItem('userData');
      this.authService.clearLogoutTimer();
    })
  );

  @Effect()
  autoLogin = this.actions$.pipe(
    ofType(AuthActions.AUTO_LOGIN),
    map(() => {
      const userData: {
        email: string,
        id: string,
        _token: string,
        _tokenExpirationDate: string
      } = JSON.parse(localStorage.getItem('userData'));
      if (!userData) {
        return { type: 'DUMMY' };
      }

      const loadedUser = new User(userData.email, userData.id, userData._token, new Date(userData._tokenExpirationDate));

      console.log(loadedUser);
      if (loadedUser.token) {
        const expirationDuration = new Date(userData._tokenExpirationDate).getTime() - new Date().getTime();
        this.authService.setLogoutTimer(expirationDuration);
        return new AuthActions.AuthenticateSuccess({
          email: loadedUser.email,
          userId: loadedUser.id,
          token: loadedUser.token,
          expirationDate: new Date(userData._tokenExpirationDate)
        });
      }
      return { type: 'DUMMY' };
    })
  );

  @Effect({ dispatch: false })
  authRedirect = this.actions$
    .pipe(
      ofType(AuthActions.AUTHENTICATE_SUCCESS),
      tap(() => {
        this.router.navigate(['/']);
      })
    );

  constructor(
    private actions$: Actions,
    private http: HttpClient,
    private router: Router,
    private authService: AuthService) { }
}
