import { Component, Input, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-long-input',
  templateUrl: './long-input.component.html',
  styleUrls: ['./long-input.component.scss'],
})
export class LongInputComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  input = new FormControl('', [Validators.required]);
  simpleInput: string = 'simpleInput';

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Введите значение в поле';
    }

    return this.email.hasError('email') ? 'Email невалидный!' : '';
  }

  @Input() placeholderName : String = new String();
  @Input() validationType : String = new String();
}
