import { Component, OnInit, Input } from '@angular/core';
import { TestItem } from './models/testItem';

@Component({
  selector: 'app-select-your-destiny',
  templateUrl: './select-your-destiny.component.html',
  styleUrls: ['./select-your-destiny.component.scss']
})
export class SelectYourDestinyComponent implements OnInit {

  @Input() testItem : TestItem
  
  constructor() { }

  ngOnInit() {
    console.log(this.testItem);
  }

}
