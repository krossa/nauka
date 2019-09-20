import { Recipe } from './recipe.model';
import { EventEmitter, Injectable } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from '../shopping-list/shopping-list.service';
import { Subject } from 'rxjs';

@Injectable()
export class RecipeService {
    recipesChanged = new Subject<Recipe[]>();
    private recipes: Recipe[] = [];
    // private recipes: Recipe[] = [
    //     new Recipe(
    //         'A test recipe name',
    //         'test description',
    //         // tslint:disable-next-line: max-line-length
    //         `https://hips.hearstapps.com/del.h-cdn.co/assets/18/11/2048x1024/landscape-1520957481-grilled-salmon-horizontal.jpg?resize=1200:*`,
    //         [
    //             new Ingredient('Salmon', 1),
    //             new Ingredient('Lemon', 3)
    //         ]),
    //     new Recipe(
    //         'Chicken Curry',
    //         `Making Indian at home doesnt have to be intimidating.
    //          This recipe comes together in under an hour! We suggest pairing it with rice or naan.`,
    //         // tslint:disable-next-line: max-line-length
    //         `https://hips.hearstapps.com/del.h-cdn.co/assets/17/31/1501791674-delish-chicken-curry-horizontal.jpg?crop=1xw:1xh;center,top&resize=768:*`,
    //         [
    //             new Ingredient('Chicken', 1),
    //             new Ingredient('Rice', 50),
    //             new Ingredient('Curry', 1)
    //         ])
    // ];

    constructor(private slService: ShoppingListService) { }

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
        this.slService.addIngredients(ingredients);
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
