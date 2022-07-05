import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { Ingredient } from 'src/app/data/containers/ingedient.interface';
import { Step } from 'src/app/data/containers/step.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { FormArray, FormControl, NgModel, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { CloseScrollStrategy } from '@angular/cdk/overlay';
import { COMMA, ENTER, X } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { Tag } from 'src/app/data/containers/tag.interface';
import { IconResolver } from '@angular/material/icon';
import { Photo } from 'src/app/data/containers/photo.interface';
import { waitForAsync } from '@angular/core/testing';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss'],
})
export class CreateRecipeComponent implements OnInit {
  file: File | null = null;
  recipe: Recipe = {
    ingredients: [],
    steps: [],
    tagsList: [],    
  };
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  tagList: Tag[] = [];

  constructor(private recipeHelper: RecipeHelper) {}

  ngOnInit(): void {
    this.initPhoto();
    document.body.scrollTop = document.documentElement.scrollTop = 0;
  }

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();
    if (value) {
      this.recipe.tagsList.push({ name: value });
    }
    event.chipInput!.clear();
  }

  remove(tag: Tag): void {
    const index = this.recipe.tagsList.indexOf(tag);
    if (index >= 0) {
      this.recipe.tagsList.splice(index, 1);
    }
  }

  createRecipeForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', [Validators.maxLength(200), Validators.required ]),
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
    if (this.getStepsControls().controls.length > 1) {
      this.getStepsControls().removeAt(index);
    }
  }

  getFile(event: any): void {
    var newImg = document.getElementById('newPhoto') as HTMLImageElement;
    this.file = event.target.files[0];    
    newImg.src = URL.createObjectURL(this.file as File);
  }

  initPhoto(): void {
    if (this.recipe.imageUrl != undefined) {
      var newImg = document.getElementById('newPhoto') as HTMLImageElement;  
      newImg.src = this.recipe.imageUrl as string;
    }
  }

  deletePhoto(): void {
    var newImg = document.getElementById('newPhoto') as HTMLImageElement;
    this.file = null;
    newImg.src = "../../../assets/create-recipe/upload-photo.png";    
  }

  saveRecipe(): void {
    let formData = { ...this.createRecipeForm.value };
    this.showPreloader();
    this.recipeHelper.createRecipe(this.toDto(formData)).subscribe(e => {
      if (this.file != null) {
        let fd = new FormData();
        fd.append('file', this.file, this.file.name);
         console.log(fd);
        let newUrl: string = 'https://localhost:7192/api/Recipe/'+ e.recipeId +'/updatePhoto';      
        this.recipeHelper.updatePhoto(newUrl, fd ).subscribe( e => {
          this.hidePreloader();
          window.location.href='http://localhost:4200/recipes';
        });
        setTimeout(()=> {
          this.hidePreloader();
          window.location.href='http://localhost:4200/recipes';
        }, 2000); 
        
      }
    
    } );

    this.recipe.ingredients = [];
    this.recipe.steps = [];
  }

  toDto(formData: any): Recipe {
    this.recipe.recipeId = 0;
    this.recipe.authorId = 0;
    this.recipe.name = formData.name;
    this.recipe.description = formData.description;
    this.recipe.timeForCook = formData.timeForCook;
    this.recipe.numberOfServings = formData.numberOfServings;
    let i = 1;
    formData.ingredients.forEach((element: any) => {
      let ingredient: Ingredient = {
        title: element.title,
        description: element.description,
        index: i,
      };
      this.recipe.ingredients.push(ingredient);
      i++;
    });
    i = 1;
    formData.steps.forEach((element: any) => {
      let step: Step = {
        description: element.description,
        index: i,
      };
      this.recipe.steps.push(step);
      i++;
    });
    i = 1;    
    this.recipe.imageUrl = 'null';    
    return this.recipe;
  }  


  showPreloader(): void {
    let preloader = document.getElementById('preloader') as HTMLElement;
    preloader.classList.remove('visually-hidden');
  }
  
  hidePreloader(): void {
    let preloader = document.getElementById('preloader') as HTMLElement;
    preloader.classList.add('visually-hidden');
  }
}

