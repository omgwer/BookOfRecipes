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
  recipe: Recipe = {
    ingredients : [],
    steps : []
  };

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
    let formData = {...this.createRecipeForm.value};    
    this.recipeHelper.createRecipe(this.toDto(formData)).subscribe();
    this.recipe.ingredients = [];
    this.recipe.steps = [];
  }

  toDto(formData: any): Recipe {
    this.recipe.recipeId = 0;
    this.recipe.authorId = 0;
    this.recipe.name = formData.name;
    this.recipe.description = formData.description;
    this.recipe.tagsList = formData.tagsList;
    this.recipe.timeForCook = formData.timeForCook;
    this.recipe.numberOfServings = formData.numberOfServings;
    let i = 1;
    console.log(formData);
    formData.ingredients.forEach((element: any) => {
      let ingredient: Ingredient  = {
        title : element.title,
        description : element.description,
        order : i,
      }
      this.recipe.ingredients.push(ingredient);
      i++;
    });
    i = 1;
    formData.steps.forEach((element: any) => {
      let step: Step  = {
        description : element.description,
        order : i,
      }
      this.recipe.steps.push(step);
      i++;
    })
    i = 1;
    this.recipe.imageUrl = 'null';    
    return this.recipe;
  }
}
