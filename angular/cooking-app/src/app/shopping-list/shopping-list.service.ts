import { Ingredient } from '../shared/ingredient.model';
import { Subject } from 'rxjs';

export class ShoppingListService {
    ingredientsChanged = new Subject<Ingredient[]>();
    startedEditting = new Subject<number>();
    private ingredients: Ingredient[] = [
        new Ingredient('Apples', 5),
        new Ingredient('Tomatos', 10)
    ];

    getIngredients() {
        return this.ingredients.slice();
    }

    getIngredient(i: number) {
        return this.ingredients[i];
    }

    addIngredient(ingridient: Ingredient) {
        this.ingredients.push(ingridient);
        this.ingredientsChangedEmmit();
    }

    addIngredients(ingredients: Ingredient[]) {
        this.ingredients.push(...ingredients);
        this.ingredientsChangedEmmit();
    }

    updateIngredient(i: number, ingredient: Ingredient) {
        this.ingredients[i] = ingredient;
        this.ingredientsChangedEmmit();
    }

    deleteIngredient(i: number) {
        this.ingredients.splice(i, 1);
        this.ingredientsChangedEmmit();
    }

    private ingredientsChangedEmmit() {
        this.ingredientsChanged.next(this.ingredients.slice());
    }
}
