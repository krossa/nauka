import { Component, OnInit } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from './shopping-list.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit {
  ingredients: Ingredient[];

  constructor(private shoppingListService: ShoppingListService) { }

  ngOnInit() {
    this.ingredientsChanged(this.shoppingListService.getIngredients());
    this.shoppingListService.ingredientsChanged.subscribe(
      (ingriedients: Ingredient[]) => {
        this.ingredientsChanged(ingriedients);
      }
    );
  }

  private ingredientsChanged(ingredients: Ingredient[]) {
    this.ingredients = ingredients;
  }
}
