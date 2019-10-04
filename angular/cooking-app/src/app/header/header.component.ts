import { Component, OnInit, OnDestroy } from '@angular/core';

import { DataStorageService } from '../shared/data-storage.service';
import { AuthService } from '../auth/auth.service';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-header',
    templateUrl: 'header.component.html'
})
export class HeaderComponent implements OnInit, OnDestroy {
    userSub = new Subscription();
    isAuth = false;

    constructor(private dataStorageService: DataStorageService, private authService: AuthService) { }

    ngOnInit() {
        this.userSub = this.authService.user
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
        this.authService.logout();
    }
}
