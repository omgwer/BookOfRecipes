import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-yellow-button',
  templateUrl: './yellow-button.component.html',
  styleUrls: ['./yellow-button.component.scss']
})
export class YellowButtonComponent {
  emptyString: String = "";

  @Input() buttonValue?: String;
  @Input() routingUrl?: String;
  @Input() isAddRecipeButton?: Boolean;
  @Input() isEditRecipeButton?: Boolean;
  @Input() action?: String;

  //методы для желтой кнопки
  openLoginForm(): void {};
  openCreateAccountForm(): void {};
  search(): void {};
  saveRecipe(): void {};
}
