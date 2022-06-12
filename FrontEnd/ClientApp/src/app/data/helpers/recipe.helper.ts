import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Recipe } from '../containers/recipe.interface';

@Injectable()
export class RecipeHelper {
    private baseUrl: string = 'https://localhost:7192';
    constructor(private http: HttpClient) {
        this.http = http;
    }

    createRecipe(recipe: Recipe): Observable<Recipe> {
        return this.http.post<Recipe>(this.baseUrl + '/api/CreateRecipe/test', recipe);
    }
}