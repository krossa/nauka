import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducer';
import { map } from 'rxjs/operators';
import * as AuthActions from '../auth/store/auth.actions';
import * as RecipeActions from '../recipes/store/recipe.actions';

@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {
  userSub = new Subscription();
  isAuth = false;

  constructor(private store: Store<fromApp.AppState>) { }

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
    this.store.dispatch(new RecipeActions.StoreRecipes());
  }

  onGetData() {
    // this.dataStorageService.getRecipes().subscribe();
    this.store.dispatch(new RecipeActions.FetchRecipes());
  }

  onLogout() {
    this.store.dispatch(new AuthActions.Logout());
  }
}
