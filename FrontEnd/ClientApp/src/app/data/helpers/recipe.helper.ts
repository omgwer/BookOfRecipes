import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from '../containers/recipe.interface';
import { Photo } from '../containers/photo.interface';
import { of } from 'rxjs';

export interface IOptionResponse {
  message: string;
  model?: Recipe[];
}

@Injectable()
export class RecipeHelper {
  private baseUrl: string = 'https://localhost:7192';
  constructor(private http: HttpClient) {
    this.http = http;
  }

  createRecipe(recipe: Recipe): Observable<Recipe> {    
    return this.http.post<Recipe>(this.baseUrl + '/api/Recipe/save', recipe);
  }

  getRecipeList(index: Number): Observable<Recipe[]>{
    return this.http.get<Recipe[]>(this.baseUrl + '/api/Recipe/list/' + index);
  } 

  updatePhoto(url: string, file: FormData) : Observable<Recipe> {    
    return this.http.post<Recipe>(url, file);
  }

  getRecipe(index: Number): Observable<Recipe> {
     return this.http.get<Recipe>(this.baseUrl + '/api/Recipe/' + index);
  }

  deleteRecipe(index: Number): Observable<String> {
    return this.http.get<String>(this.baseUrl + '/api/Recipe/' + index + '/delete');
  }
}