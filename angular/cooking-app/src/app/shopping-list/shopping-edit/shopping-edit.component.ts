import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Ingredient } from 'src/app/shared/ingredient.model';
import { ShoppingListService } from '../shopping-list.service';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit, OnDestroy {
  @ViewChild('f') form: NgForm;
  private subscription: Subscription;
  editMode = false;
  editedItemIndex: number;
  editedItem: Ingredient;

  constructor(private shoppingListService: ShoppingListService) { }

  ngOnInit() {
    console.log('1');
    console.log(this.shoppingListService);
    this.subscription = this.shoppingListService.startedEditting
      .subscribe(
        (i: number) => {
          this.getEditedItem(i);
        }
      );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  onSubmit() {
    const name = this.form.value.name;
    const amount = this.form.value.amount;
    const item = new Ingredient(name, amount);
    this.editMode ?
      this.shoppingListService.updateIngredient(this.editedItemIndex, item) :
      this.shoppingListService.addIngredient(item);
  }

  onClear() {
    this.editMode = false;
    this.editedItem = null;
    this.editedItemIndex = null;
    this.form.reset();
  }

  onDelete() {
    this.shoppingListService.deleteIngredient(this.editedItemIndex);
    this.onClear();
  }

  private getEditedItem(i: number) {
    this.editedItemIndex = i;
    this.editedItem = this.shoppingListService.getIngredient(i);
    this.editMode = true;
    this.form.setValue({
      name: this.editedItem.name,
      amount: this.editedItem.amount
    });
  }
}
