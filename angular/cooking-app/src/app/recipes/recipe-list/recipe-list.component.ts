import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Recipe } from '../recipe.model';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  @Output() recipeSelected = new EventEmitter<Recipe>();

  recipes: Recipe[] = [
    new Recipe('A test recipe name', 'test description',
      'https://hips.hearstapps.com/del.h-cdn.co/assets/18/11/2048x1024/landscape-1520957481-grilled-salmon-horizontal.jpg?resize=1200:*'),
    new Recipe('Chicken Curry',
      'Making Indian at home doesnt have to be intimidating. This recipe comes together in under an hour! We suggest pairing it with rice or naan.',
      'https://hips.hearstapps.com/del.h-cdn.co/assets/17/31/1501791674-delish-chicken-curry-horizontal.jpg?crop=1xw:1xh;center,top&resize=768:*')
  ];

  constructor() { }

  ngOnInit() {
  }

  onRecipeSelected(recipe: Recipe) {
    this.recipeSelected.emit(recipe);
  }

}
