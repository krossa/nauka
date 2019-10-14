import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../auth/auth.guard';
import { EmptyRecipeComponent } from './empty-recipe/empty-recipe.component';
import { RecipesResolverService } from './recipes-resolver.service';
import { RecipesComponent } from './recipes.component';
import { RecipeDetailComponent } from './recipe-detail/recipe-detail.component';
import { RecipeEditComponent } from './recipe-edit/recipe-edit.component';

const routes: Routes = [
    {
        path: '',
        canActivate: [AuthGuard],
        component: RecipesComponent,
        children: [
            { path: '', component: EmptyRecipeComponent },
            { path: 'new', component: RecipeEditComponent },
            {
                path: ':id',
                component: RecipeDetailComponent,
                resolve: [RecipesResolverService]
            },
            {
                path: ':id/edit',
                component: RecipeEditComponent,
                resolve: [RecipesResolverService]
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]

})
export class RecipesRoutingModule { }
