import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipesListComponent } from './recipes/recipes-list/recipes-list.component';

const routes: Routes = [
  { path: '', component: RecipesListComponent },
  { path: 'recipes', component: RecipesListComponent },
  { path: '**', component: RecipesListComponent, pathMatch: 'full' },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
