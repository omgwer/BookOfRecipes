import { Component, Input, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-droplist-input',
  templateUrl: './droplist-input.component.html',
  styleUrls: ['./droplist-input.component.scss']
})
export class DroplistInputComponent {
  cookingTime: String = "cookingTime";
  numberOfServings: String = "numberOfServings";
  input = new FormControl('', [Validators.required]);

  getErrorMessage() {  
    return this.input.hasError('required') ? 'Выберите значение из списка' : '';
  }

  @Input() placeholderName?: String;
  @Input() dropListType?: String;  
}
