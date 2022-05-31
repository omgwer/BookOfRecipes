import { Component } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { Ingredient } from 'src/app/data/containers/ingedient.interface';
import { Step } from 'src/app/data/containers/step.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { NgModel} from '@angular/forms';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss'],
})
export class CreateRecipeComponent {
  recipe: Recipe = {
    ingredients:[{}], 
    steps: [{}]
  };  
  file: any;
  
  constructor(private recipeHelper: RecipeHelper) {}

  addHeaderIngredient(): void {
    this.recipe.ingredients.push({});
  }

  deleteHeaderIngredient(item: Ingredient): void {
    this.recipe.ingredients = this.recipe.ingredients.filter(
      (ingredient) => ingredient != item
    );
  }

  addStep(): void {
    this.recipe.steps.push({});
  }

  deleteStep(item: Step): void {
    this.recipe.steps = this.recipe.steps.filter((steps) => steps != item);
    this.updateSteps();
  }

  updateSteps(): void {
    let i = 0;
    this.recipe.steps.forEach(step => {
      step.order = i;
      i++;
    }); 
  }

  getFile(event: any): void {
    this.file = event.target.files[0];
  }

  saveRecipe(): void {
    this.recipe.authorId = 0;
    this.recipe.imageUrl = 'null';
    
    this.recipeHelper.createRecipe(this.recipe).subscribe();
  }

  updateTagsList(event : any): void {
    this.recipe.tagsList = event.target; // доделать
  }
}
