import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { MatInputModule } from '@angular/material/input';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { CreateRecipeComponent } from './pages/create-recipe/create-recipe.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { RecipeHelper } from './data/helpers/recipe.helper';
import { HttpClientModule } from '@angular/common/http';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RecipesComponent } from './pages/recipes/recipes.component';
import {MatChipsModule} from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { EditRecipeComponent } from './pages/edit-recipe/edit-recipe.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainPageComponent,
    CreateRecipeComponent,
    NotFoundPageComponent,
    RecipesComponent,
    EditRecipeComponent,        
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  providers: [RecipeHelper],
  bootstrap: [AppComponent],
})
export class AppModule {}
