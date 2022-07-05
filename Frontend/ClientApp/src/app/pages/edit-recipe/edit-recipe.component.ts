import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.scss']
})
export class EditRecipeComponent implements OnInit {
  recipe: Recipe = {
    ingredients : [],
    steps : [],
    tagsList : []
  };

  constructor(private recipeHelper: RecipeHelper) { }

  ngOnInit(): void {    
    this.initRecipe();
    document.body.scrollTop = document.documentElement.scrollTop = 0;
  }

  initRecipe(): void {
    this.showPreloader();
    let recipeId : number =  Number.parseInt(window.location.href.replace('http://localhost:4200/recipes/', ''));    
    this.recipeHelper.getRecipe(recipeId).subscribe(e => {
      this.hidePreloader();
      this.recipe = e;
    });
  }

  deleteRecipe(recipeId?: Number):void {
    this.showPreloader();
    this.recipeHelper.deleteRecipe(recipeId as Number).subscribe(e =>  {
      this.hidePreloader();
      }
    );
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
