import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Store } from '@ngrx/store';

import { Ingredient } from 'src/app/shared/ingredient.model';
import * as ShoppingListActions from '../store/shopping-list.actions';
import * as fromShoppingList from '../store/shopping-list.reducer';


@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit, OnDestroy {
  @ViewChild('f', { static: true }) form: NgForm;
  private subscription: Subscription;
  editMode = false;
  editedItem: Ingredient;

  constructor(private store: Store<fromShoppingList.AppState>) { }

  ngOnInit() {
    this.subscription = this.store.select('shoppingList').subscribe(stateData => {
      if (stateData.editedIngredientId > -1) {
        this.getEditedItem(stateData.editedIngredient);
      } else {
        this.editMode = false;
      }
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.store.dispatch(new ShoppingListActions.StopEdit());
  }

  onSubmit() {
    const name = this.form.value.name;
    const amount = this.form.value.amount;
    const item = new Ingredient(name, amount);
    this.editMode ?
      this.store.dispatch(new ShoppingListActions.UpdateIngredient(item)) :
      this.store.dispatch(new ShoppingListActions.AddIngredient(item));
  }

  onClear() {
    this.editMode = false;
    this.form.reset();
    this.store.dispatch(new ShoppingListActions.StopEdit());
  }

  onDelete() {
    this.store.dispatch(new ShoppingListActions.DeleteIngredient());
    this.onClear();
  }

  private getEditedItem(item: Ingredient) {
    this.editedItem = item;
    this.editMode = true;
    this.form.setValue({
      name: this.editedItem.name,
      amount: this.editedItem.amount
    });
  }
}
