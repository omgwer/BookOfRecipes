import { Component, OnInit } from '@angular/core';
import { RecipeHelper } from 'src/app/data/helpers/recipe.helper';
import { Recipe } from 'src/app/data/containers/recipe.interface';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss'],
})
export class RecipesComponent implements OnInit {
  listIndex: number;
  recipeList: Recipe[] = [];
  input = new FormControl('');

  constructor(private recipeHelper: RecipeHelper) {
    this.listIndex = 0;
  }

  ngOnInit(): void {
    this.pushRecipeElementForList();
  }

  getErrorMessage() {
    return 'Введите значение в поле';
  }

  pushRecipeElementForList(): void {
    this.showPreloader();
    this.recipeHelper.getRecipeList(this.listIndex).subscribe((x) => {
      x.forEach((e) => this.recipeList.push(e));
      this.listIndex++;
      setInterval(()=> this.hidePreloader(), 4000);
    });
    setInterval(()=> this.hidePreloader(), 4000);
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
