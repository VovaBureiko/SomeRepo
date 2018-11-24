import { Component, OnInit } from '@angular/core';
import { SpecializationService } from '../../services/specializationService';
import { ISpecialization } from '../../models/specialization';
import { TestItem } from '../select-your-destiny/models/testItem';

@Component({
  selector: 'app-testing-page',
  templateUrl: './testing-page.component.html',
  styleUrls: ['./testing-page.component.css']
})
export class TestingPageComponent implements OnInit {

  _specializations : TestItem[]
  constructor(private _specializationService : SpecializationService) { }

  ngOnInit() {
    this._specializationService.getSpecializations().then(response => {
       this._specializations = response.map(element => {
            return new TestItem(element.id, element.label);
        });
    })
  }
}