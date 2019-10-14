import { NgModule } from '@angular/core';

import { AuthComponent } from './auth.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

const routes: Routes = [
    { path: '', component: AuthComponent }
];

@NgModule({
    declarations: [AuthComponent],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(routes),
        SharedModule]
})
export class AuthModule { }
