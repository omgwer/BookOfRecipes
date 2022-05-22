import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.scss']
})
export class CreateRecipeComponent {
  tests: Number[] = [1,2,3];

  saveRecipe():void {};

  addHeaderIngredient(): void {
    console.log(this.tests.length + 1);
  };

  deleteHeaderIngredient(): void {
    this.tests = this.tests.filter((task) => task != 2)
  };

  //onDelete(taskId: number): void {      
    // this.todoService.deleteTask(taskId).subscribe(()=>{
    //   this.tasks = this.tasks.filter((task) => task.id != taskId);
    // }); 
}
