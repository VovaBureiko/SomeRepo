import { Component, OnInit } from '@angular/core';
import { SpecializationService } from '../../services/specializationService';

@Component({
  selector: 'app-testing-page',
  templateUrl: './testing-page.component.html',
  styleUrls: ['./testing-page.component.css']
})
export class TestingPageComponent implements OnInit {

  constructor(private specializationService : SpecializationService) { }

  ngOnInit() {
  }
}
