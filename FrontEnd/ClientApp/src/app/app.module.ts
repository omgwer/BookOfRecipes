import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { TopBlockComponent } from './components/top-block/top-block.component';
import { TagsBlockComponent } from './components/tags-block/tags-block.component';
import { TagsListComponent } from './shared/tags-list/tags-list.component';
import { RecipeOfDayComponent } from './components/recipe-of-day/recipe-of-day.component';
import { SearchRecipesMainPageComponent } from './components/search-recipes-main-page/search-recipes-main-page.component';
import { SearchRecipeFormComponent } from './shared/search-recipe-form/search-recipe-form.component';
import { MatInputModule } from '@angular/material/input';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { CreateRecipeComponent } from './pages/create-recipe/create-recipe.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { SimpleInputComponent } from './shared/inputs/simple-input/simple-input.component';
import { DroplistInputComponent } from './shared/inputs/droplist-input/droplist-input.component';
import { YellowButtonComponent } from './shared/buttons/yellow-button/yellow-button.component';
import { WhiteButtonComponent } from './shared/buttons/white-button/white-button.component';
import { LongInputComponent } from './shared/inputs/long-input/long-input.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import { RecipeHelper } from './data/helpers/recipe.helper';
import { HttpClientModule } from '@angular/common/http';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent,
    HeaderComponent, FooterComponent, TopBlockComponent, TagsBlockComponent, TagsListComponent, RecipeOfDayComponent, SearchRecipesMainPageComponent, SearchRecipeFormComponent, MainPageComponent, CreateRecipeComponent, NotFoundPageComponent, SimpleInputComponent, DroplistInputComponent, YellowButtonComponent, WhiteButtonComponent, LongInputComponent,],
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
  ],
  providers: [RecipeHelper],
  bootstrap: [AppComponent],
})
export class AppModule {}