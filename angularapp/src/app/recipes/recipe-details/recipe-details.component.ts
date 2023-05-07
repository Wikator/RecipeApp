import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from '../../_models/recipe';
import { RecipesService } from '../../_services/recipes.service';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  recipe: Recipe | undefined;


  constructor(private recipesService: RecipesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.recipesService.getRecipe(id).subscribe({
        next: recipe => this.recipe = recipe,
        error: err => console.log(err)
      })
    }
  }
}
