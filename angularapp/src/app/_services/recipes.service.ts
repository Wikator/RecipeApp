import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { PaginationParams } from '../_models/paginationParams';
import { Recipe } from '../_models/recipe';
import { RecipeCard } from '../_models/recipeCard';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  baseUrl = environment.apiUrl + 'recipes/';

  constructor(private http: HttpClient) { }


  getRecipes(paginationParams: PaginationParams) {
    const params = this.getPaginatedParams(paginationParams.pageNumber, paginationParams.pageSize);

    return this.getPaginatedResult<RecipeCard[]>(this.baseUrl, params);
  }

  getRecipe(id: number | string) {
    return this.http.get<Recipe>(this.baseUrl + id);
  }

  createRecipe(recipe: Recipe) {
    return this.http.post(this.baseUrl, recipe);
  }

  seedRecipes() {
    return this.http.post(this.baseUrl + 'seed', null);
  }

  private getPaginatedParams(pageNumber: number, pageSize: number) {
    let params = new HttpParams();

    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return params;
  }

  private getPaginatedResult<T>(url: string, params: HttpParams) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.http.get<T>(url, { observe: 'response', params }).pipe(
      map(response => {
        if (response.body) {
          paginatedResult.result = response.body;
        }
        const pagination = response.headers.get('Pagination');
        if (pagination) {
          paginatedResult.pagination = JSON.parse(pagination);
        }
        return paginatedResult;
      })
    )
  }
}
