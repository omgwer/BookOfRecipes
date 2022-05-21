import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-simple-input',
  templateUrl: './simple-input.component.html',
  styleUrls: ['./simple-input.component.scss']
})
export class SimpleInputComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() placeholderName : String = new String();

}
