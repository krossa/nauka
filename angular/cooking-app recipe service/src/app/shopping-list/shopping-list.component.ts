import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Ingredient } from '../shared/ingredient.model';
import { LoggingService } from '../logging.service';
import * as fromShoppingList from './store/shopping-list.reducer';
import * as shoppingListActions from './store/shopping-list.actions';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent implements OnInit {
  ingredients: Observable<{ ingredients: Ingredient[] }>;
  // private igChangeSub: Subscription;

  constructor(
    private loggingService: LoggingService,
    private store: Store<fromShoppingList.AppState>) { }

  ngOnInit() {
    this.ingredients = this.store.select('shoppingList');
    this.loggingService.printLog('Hello from shopping list');
  }

  OnEditItem(i: number) {
    this.store.dispatch(new shoppingListActions.StartEdit(i));
  }
}
