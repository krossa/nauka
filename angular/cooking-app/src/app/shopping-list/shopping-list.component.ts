import { Component, OnInit, OnDestroy } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from './shopping-list.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit, OnDestroy {
  ingredients: Ingredient[];
  private igChangeSub: Subscription;

  constructor(private shoppingListService: ShoppingListService) { }

  ngOnInit() {
    this.ingredientsChanged(this.shoppingListService.getIngredients());
    this.igChangeSub = this.shoppingListService.ingredientsChanged.subscribe(
      (ingredients: Ingredient[]) => {
        this.ingredientsChanged((ingredients));
      }
    );
  }

  ngOnDestroy() {
    this.igChangeSub.unsubscribe();
  }

  private ingredientsChanged(ingredients: Ingredient[]) {
    this.ingredients = ingredients;
  }

  OnEditItem(i: number) {
    this.shoppingListService.startedEditting.next(i);
  }
}
