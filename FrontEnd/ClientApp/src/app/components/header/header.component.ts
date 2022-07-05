import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit {
  public href: string = "";
  

  constructor() {}

  ngOnInit() {
    if (window.location.href == 'http://localhost:4200/recipes') {
      this.switchRecipes();
    }
  }

  switchToMain() {
    let main : HTMLElement = document.getElementById('main') as HTMLElement;
    let recipes : HTMLElement = document.getElementById('recipes') as HTMLElement;
    let likes : HTMLElement = document.getElementById('liks') as HTMLElement;
    main.classList.add('selected');
    recipes.classList.remove('selected');    
    likes.classList.remove('selected');    
  }

  switchRecipes() {
    let main : HTMLElement = document.getElementById('main') as HTMLElement;
    let recipes : HTMLElement = document.getElementById('recipes') as HTMLElement;
    let likes : HTMLElement = document.getElementById('likes') as HTMLElement;
    main.classList.remove('selected');
    recipes.classList.add('selected');    
    likes.classList.remove('selected');
  } 

  switchLikes() {
    let main : HTMLElement = document.getElementById('main') as HTMLElement;
    let recipes : HTMLElement = document.getElementById('recipes') as HTMLElement;
    let likes : HTMLElement = document.getElementById('likes') as HTMLElement;
    main.classList.remove('selected');
    recipes.classList.remove('selected');    
    likes.classList.add('selected');
  }

}
