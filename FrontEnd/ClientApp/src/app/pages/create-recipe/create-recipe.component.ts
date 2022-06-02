import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { Ingredient } from 'src/app/data/containers/ingedient.interface';
import { Step } from 'src/app/data/containers/step.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { FormArray, FormControl, NgModel, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { CloseScrollStrategy } from '@angular/cdk/overlay';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss'],
})
export class CreateRecipeComponent implements OnInit {
  file: any;

  createRecipeForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    tagsList: new FormControl('', Validators.required),
    timeForCook: new FormControl('', Validators.required),
    numberOfServings: new FormControl('', Validators.required),
    ingredients: new FormArray([
      new FormGroup({
        title: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
      }),
    ]),
    steps: new FormArray([
      new FormGroup({
        description: new FormControl('', Validators.required),
      }),
    ]),
  });

  ngOnInit(): void {
  }

  constructor(private recipeHelper: RecipeHelper) {}

  addHeaderIngredient() {
    const control = new FormGroup({
      title: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
    });
    this.getIngredientControls().push(control);
  }

  getIngredientControls() {
    return this.createRecipeForm.get('ingredients') as FormArray;
  }

  deleteHeaderIngredient(index: number): void {
    if (this.getIngredientControls().controls.length > 1) {
      this.getIngredientControls().removeAt(index);
    }
  }

  getStepsControls() {
    return this.createRecipeForm.get('steps') as FormArray;
  }

  addStep(): void {
    const control = new FormGroup({
      description: new FormControl('', Validators.required),
    });
    this.getStepsControls().push(control);
  }

  deleteStep(index: number): void {
    if (this.getStepsControls().controls.length > 1)
    {
      this.getStepsControls().removeAt(index);
    }
  }

  getFile(event: any): void {
    this.file = event.target.files[0];
  }

  saveRecipe(): void {   
    let formData = {...this.createRecipeForm.value}
    formData['recipeId'] = '0';
    formData['authorId'] = '0';
    formData['imageUrl'] = 'null';
    this.recipeHelper.createRecipe(formData).subscribe();
  }
}
