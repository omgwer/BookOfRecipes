import { newArray } from '@angular/compiler/src/util';
import { Component } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { Ingredient } from 'src/app/data/containers/recipe.interface';
import { Step } from 'src/app/data/containers/recipe.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { NgModel} from '@angular/forms';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss'],
})
export class CreateRecipeComponent {
  ingredients: number[] = [1];
  steps: number[] = [1];
  file: any;
  ingredient: Ingredient = {title: '', description: ''};

  constructor(private recipeHelper: RecipeHelper) {}

  addHeaderIngredient(): void {
    this.ingredients.push(this.ingredients.length + 1);
  }

  deleteHeaderIngredient(item: number): void {
    this.ingredients = this.ingredients.filter(
      (ingredient) => ingredient != item
    );
    this.updateHeaderArray();
  }

  updateHeaderArray(): void {
    let arr: number = this.ingredients.length;
    let i: number;
    let newArr: number[] = [];
    for (i = 1; i <= arr; i++) {
      newArr.push(i);
    }
    this.ingredients = newArr;
  }

  addStep(): void {
    this.steps.push(this.steps.length + 1);
  }

  deleteStep(item: number): void {
    this.steps = this.steps.filter((steps) => steps != item);
    this.updateStep();
  }

  updateStep(): void {
    let arr: number = this.steps.length;
    let i: number;
    let newArr: number[] = [];
    for (i = 1; i <= arr; i++) {
      newArr.push(i);
    }
    this.steps = newArr;
  }

  getFile(event: any): void {
    this.file = event.target.files[0];
    console.log(this.file);
  }

  saveRecipe(): void {
    let newRecipe: Recipe = {};
    newRecipe.authorId = 0;
    newRecipe.imageUrl = 'null';
    this.getEngridients();
    this.recipeHelper.createRecipe(newRecipe).subscribe();
  }

  getEngridients(): void {
    console.log(this.ingredient.description);  
  }
}
