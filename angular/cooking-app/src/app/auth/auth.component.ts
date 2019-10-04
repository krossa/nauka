import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { AuthService, AuthResponseData } from './auth.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  isLoginMode = true;
  isLoading = false;
  error: string = null;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  onSwithMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      return;
    }
    this.error = null;
    const email = form.value.email;
    const password = form.value.password;
    let authObj: Observable<AuthResponseData>;

    this.isLoading = true;

    if (this.isLoginMode) {
      authObj = this.authService.login(email, password);
    } else {
      authObj = this.authService.signup(email, password);
    }

    authObj.subscribe(
      resData => {
        console.log(resData);
        this.isLoading = false;
        this.router.navigate(['/recipes']);
      },
      errorMessage => {
        console.log(errorMessage);
        this.error = errorMessage;
        this.isLoading = false;
      });

    form.reset();
  }
}
