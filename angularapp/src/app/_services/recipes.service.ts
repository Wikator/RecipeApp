import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Recipe } from '../_models/recipe';
import { RecipeCard } from '../_models/recipeCard';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  baseUrl = environment.apiUrl + 'recipes/';

  constructor(private http: HttpClient) { }


  getRecipes() {
    return this.http.get<RecipeCard[]>(this.baseUrl);
  }

  getRecipe(id: number | string) {
    return this.http.get<Recipe>(this.baseUrl + id);
  }

  createRecipe(recipe: Recipe) {
    return this.http.post(this.baseUrl, recipe);
  }
}
