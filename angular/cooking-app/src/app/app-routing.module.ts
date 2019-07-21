import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { HomeComponent } from './home/home.component';
import { RecipesComponent } from './recipes/recipes.component';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { EmptyRecipeComponent } from './recipes/empty-recipe/empty-recipe.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeEditComponent } from './recipes/recipe-edit/recipe-edit.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'recipes', component: RecipesComponent, children: [
            { path: '', component: EmptyRecipeComponent },
            { path: ':id/edit', component: RecipeEditComponent },
            { path: 'new', component: RecipeEditComponent },
            { path: ':id', component: RecipeDetailComponent }

        ]
    },
    { path: 'shopping-list', component: ShoppingListComponent },
    { path: '**', component: PageNotFoundComponent }
];
// const appRoutes: Routes = [
//     { path: '', component: HomeComponent },
//     {
//         path: 'servers', canActivateChild: [AuthGuard], component: ServersComponent, children: [
//             { path: ':id', component: ServerComponent, resolve: { myserver: ServerResolver } },
//             { path: ':id/edit', component: EditServerComponent, canDeactivate: [CanDeactivateGuard] }
//         ]
//     },
//     {
//         path: 'users', component: UsersComponent, children: [
//             { path: ':id/:name', component: UserComponent }
//         ]
//     },
//     // { path: 'not-found', component: PageNotFoundComponent },
//     { path: 'not-found', component: ErrorPageComponent, data: { message: 'Page not found!xxxx' } },
//     { path: '**', redirectTo: '/not-found', pathMatch: 'full' }
// ];

@NgModule({
    imports: [
        // RouterModule.forRoot(appRoutes, { useHash: true })
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {

}
