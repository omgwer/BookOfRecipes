import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  input = new FormControl('', Validators.required);
  simpleInput: string = 'simpleInput';

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Введите значение в поле';
    }

    return this.email.hasError('email') ? 'Email невалидный!' : '';
  }
}
