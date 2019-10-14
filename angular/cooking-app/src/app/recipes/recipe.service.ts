import { Store } from '@ngrx/store';
import { EventEmitter, Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import { Recipe } from './recipe.model';
import { Ingredient } from '../shared/ingredient.model';
import * as ShoppingListActions from '../shopping-list/store/shopping-list.actions';
import * as fromShoppingList from '../shopping-list/store/shopping-list.reducer';


@Injectable()
export class RecipeService {
  recipesChanged = new Subject<Recipe[]>();
  private recipes: Recipe[] = [];

  constructor(private store: Store<fromShoppingList.AppState>) { }

  setRecipes(recipes: Recipe[]) {
    this.recipes = recipes;
    this.recipesChangedEmmit();
  }

  getRecipe(id: number) {
    return this.recipes[id];
  }

  getRecipes() {
    return this.recipes.slice();
  }

  addIngredientsToShoppingList(ingredients: Ingredient[]) {
    this.store.dispatch(new ShoppingListActions.AddIngredients(ingredients));
  }

  addRecipe(recipe: Recipe) {
    this.recipes.push(recipe);
    this.recipesChangedEmmit();
  }

  updateRecipe(index: number, recipe: Recipe) {
    this.recipes[index] = recipe;
    this.recipesChangedEmmit();
  }

  deleteRecipe(index: number) {
    this.recipes.splice(index, 1);
    this.recipesChangedEmmit();
  }

  private recipesChangedEmmit() {
    this.recipesChanged.next(this.recipes.slice());
  }
}
