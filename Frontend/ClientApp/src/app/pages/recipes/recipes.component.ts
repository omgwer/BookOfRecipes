import { Component, OnInit } from '@angular/core';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { Recipe } from 'src/app/data/containers/recipe.interface';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent implements OnInit {
  listIndex: number;
  testArr: Recipe[] = [];

  constructor(private recipeHelper: RecipeHelper) {
      this.listIndex = 0;
   }

  ngOnInit(): void {
    this.recipeHelper.getRecipeList(this.listIndex).subscribe(x => {
      this.testArr = x;
    });
  }
}
