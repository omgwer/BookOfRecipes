import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss']
})
export class CreateRecipeComponent {
  tests: Number[] = [1, 2,3];

  saveRecipe():void {};

  addHeaderIngredient(): void {

  };
}
