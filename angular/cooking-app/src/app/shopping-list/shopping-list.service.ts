import { Ingredient } from '../shared/ingredient.model';
import { Subject } from 'rxjs';

export class ShoppingListService {
    ingredientsChanged = new Subject<Ingredient[]>();
    private ingredients: Ingredient[] = [
        new Ingredient('Apples', 5),
        new Ingredient('Tomatos', 10)
    ];

    getIngredients() {
        return this.ingredients.slice();
    }

    addIngredient(ingridient: Ingredient) {
        this.ingredients.push(ingridient);
        this.ingredientsChanged.next(this.ingredients.slice());
    }

    addIngridients(ingredients: Ingredient[]) {
        this.ingredients.push(...ingredients);
        this.ingredientsChanged.next(this.ingredients);
    }
}
