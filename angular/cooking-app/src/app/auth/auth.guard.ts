import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducer';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private store: Store<fromApp.AppState>) { }

  canActivate(route: ActivatedRouteSnapshot, router: RouterStateSnapshot)
    : boolean | Promise<boolean> | Observable<boolean | UrlTree> {
    return this.store.select('auth')
      .pipe(
        take(1),
        map(authState => authState.user),
        map(user => {
          if (!!user) {
            return true;
          }
          return this.router.createUrlTree(['./auth']);
        }));
  }
}
