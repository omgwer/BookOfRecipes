import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-long-input',
  templateUrl: './long-input.component.html',
  styleUrls: ['./long-input.component.scss'],
})
export class LongInputComponent {

  ngOnInit(): void {}

  @Input() placeholderName?: String;
}
