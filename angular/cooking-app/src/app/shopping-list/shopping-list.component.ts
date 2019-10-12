import { Component, OnInit, OnDestroy } from '@angular/core';
import { Ingredient } from '../shared/ingredient.model';
import { ShoppingListService } from './shopping-list.service';
import { Subscription } from 'rxjs';
import { LoggingService } from '../logging.service';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit, OnDestroy {
  ingredients: Ingredient[];
  private igChangeSub: Subscription;

  constructor(private shoppingListService: ShoppingListService, private loggingService: LoggingService) { }

  ngOnInit() {
    this.ingredientsChanged(this.shoppingListService.getIngredients());
    this.igChangeSub = this.shoppingListService.ingredientsChanged.subscribe(
      (ingredients: Ingredient[]) => {
        this.ingredientsChanged((ingredients));
      }
    );

    this.loggingService.printLog('Hello from shopping list');
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
