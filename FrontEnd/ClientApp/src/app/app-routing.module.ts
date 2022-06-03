import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from "../../src/app/pages/main-page/main-page.component";
import { CreateRecipeComponent } from "../../src/app/pages/create-recipe/create-recipe.component";
import { NotFoundPageComponent } from "../../src/app/pages/not-found-page/not-found-page.component";

const appRoutes: Routes =[
  { path: '', component: MainPageComponent},
  { path: 'create-recipe', component: CreateRecipeComponent },
  { path: '**' , redirectTo: 'error404'},
  { path: 'error404', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
