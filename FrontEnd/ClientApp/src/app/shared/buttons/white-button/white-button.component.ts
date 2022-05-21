import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-white-button',
  templateUrl: './white-button.component.html',
  styleUrls: ['./white-button.component.scss']
})
export class WhiteButtonComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() buttonValue? : String;

}
