import { Component } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { Ingredient } from 'src/app/data/containers/ingedient.interface';
import { Step } from 'src/app/data/containers/step.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { FormControl, NgModel, Validators} from '@angular/forms';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss'],
})
export class CreateRecipeComponent {
  recipe: Recipe = {
    ingredients:[{}], 
    steps: [{order: 1}]
  };  
  file: any;
  // clientForm: FormGroup = new FormGroup({
  //   "userName" : new FormControl('', Validators.required),
  // }
  // );
  
  constructor(private recipeHelper: RecipeHelper) {}

  email = new FormControl('', [Validators.required, Validators.email]);
  input = new FormControl('', Validators.required);
  simpleInput: string = 'simpleInput';

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Введите значение в поле';
    }

    return this.email.hasError('email') ? 'Email невалидный!' : '';
  }


  addHeaderIngredient(): void {
    this.recipe.ingredients.push({});
  }

  deleteHeaderIngredient(item: Ingredient): void {
    this.recipe.ingredients = this.recipe.ingredients.filter(
      (ingredient) => ingredient != item
    );
  }

  addStep(): void {
    this.recipe.steps.push({order: this.recipe.steps.length + 1});
  }

  deleteStep(item: Step): void {
    this.recipe.steps = this.recipe.steps.filter((steps) => steps != item);
    this.updateSteps();
  }

  updateSteps(): void {
    let i = 1;
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

  validationForm(): boolean {
    return false;
  }
}
