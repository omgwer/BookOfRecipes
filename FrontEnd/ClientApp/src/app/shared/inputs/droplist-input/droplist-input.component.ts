import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-droplist-input',
  templateUrl: './droplist-input.component.html',
  styleUrls: ['./droplist-input.component.scss']
})
export class DroplistInputComponent {
  cookingTime: String = "cookingTime";
  numberOfServings: String = "numberOfServings";
  
  @Input() placeholderName?: String;
  @Input() dropListType?: String;  
}
