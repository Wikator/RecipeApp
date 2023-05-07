import { Component, OnInit } from '@angular/core';
import { PaginatedResult } from '../../_models/pagination';
import { PaginationParams } from '../../_models/paginationParams';
import { RecipeCard } from '../../_models/recipeCard';
import { RecipesService } from '../../_services/recipes.service';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent implements OnInit {
  recipes: PaginatedResult<RecipeCard[]> | undefined;
  params: PaginationParams = { pageNumber: 1, pageSize: 8 };

  constructor(private recipesService: RecipesService) { }

  ngOnInit(): void {
    this.loadRecipes();
  }

  loadRecipes() {
    this.recipesService.getRecipes(this.params).subscribe({
      next: recipes => this.recipes = recipes,
      error: err => console.log(err)
    })
  }

  seedDatabase() {
    this.recipesService.seedRecipes().subscribe({
      next: _ => this.loadRecipes()
    });
  }

  pageChanged(event: any) {
    if (this.params.pageNumber !== event.page) {
      this.params.pageNumber = event.page;
      this.loadRecipes();
    }
  }
}
