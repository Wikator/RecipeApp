import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Recipe } from '../../_models/recipe';
import { RecipesService } from '../../_services/recipes.service';

@Component({
  selector: 'app-new-recipe',
  templateUrl: './new-recipe.component.html',
  styleUrls: ['./new-recipe.component.css']
})
export class NewRecipeComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  formInitialized = false;

  constructor(private recipesService: RecipesService, private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      ingredients: this.fb.array([]),
      sections: this.fb.array([]),
      photos: this.fb.array([])
    });
    this.formInitialized = true;
  }

  get ingredients() {
    return this.form.controls['ingredients'] as FormArray;
  }

  get sections() {
    return this.form.controls['sections'] as FormArray;
  }

  submit() {
    const recipe: Recipe = {...this.form.value, id: 0};

    recipe.sections.forEach(s => {
      if (s.description === '') {
        s.description = null;
      }
    });

    this.recipesService.createRecipe(recipe).subscribe({
      next: _ => this.router.navigate(['/recipes']),
      error: err => console.log(err)
    });
  }

  addNewIngredient() {
    const ingredientForm = this.fb.group({
      text: ['', Validators.required]
    })
    this.ingredients.push(ingredientForm);
  }

  removeIngredient(id: number) {
    this.ingredients.removeAt(id);
  }

  addNewSection() {
    const sectionForm = this.fb.group({
      title: ['', Validators.required],
      description: ['']
    })
    this.sections.push(sectionForm);
  }

  removeSection(id: number) {
    this.sections.removeAt(id);
  }
}
