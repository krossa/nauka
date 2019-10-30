import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { Ingredient } from '../shared/ingredient.model';
import { LoggingService } from '../logging.service';
import * as shoppingListActions from './store/shopping-list.actions';
import * as fromApp from '../store/app.reducer';

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
    private store: Store<fromApp.AppState>) { }

  ngOnInit() {
    this.ingredients = this.store.select('shoppingList');
    this.loggingService.printLog('Hello from shopping list');
  }

  OnEditItem(i: number) {
    this.store.dispatch(new shoppingListActions.StartEdit(i));
  }
}
