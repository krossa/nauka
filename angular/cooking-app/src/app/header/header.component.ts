import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Store } from '@ngrx/store';

import { DataStorageService } from '../shared/data-storage.service';
import * as fromApp from '../store/app.reducer';
import { map } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import * as AuthActions from '../auth/store/auth.actions';

@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {
  userSub = new Subscription();
  isAuth = false;

  constructor(
    private dataStorageService: DataStorageService,
    private store: Store<fromApp.AppState>,
    private authService: AuthService) { }

  ngOnInit() {
    this.userSub = this.store.select('auth')
      .pipe(map(authState => authState.user))
      .subscribe(user => {
        this.isAuth = !!user;
      });
  }

  ngOnDestroy() {
    this.userSub.unsubscribe();
  }

  onSaveData() {
    this.dataStorageService.storeRecipes();
  }

  onGetData() {
    this.dataStorageService.getRecipes().subscribe();
  }

  onLogout() {
    this.store.dispatch(new AuthActions.Logout());
  }
}
