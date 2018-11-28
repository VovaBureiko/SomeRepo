import { Component, OnInit, OnChanges } from '@angular/core';
import { SpecializationService } from '../../services/specializationService';
import { ISpecialization } from '../../models/specialization';
import { TestItem } from '../select-your-destiny/models/testItem';
import { ConnectionService } from 'src/app/services/testing.connection.service';
import { FormGroup } from '@angular/forms';
import { LogicService } from 'src/app/services/logic';
import { SendData } from 'src/app/models/prepearingData';
import { NgOnChangesFeature, bind } from '@angular/core/src/render3';

@Component({
  selector: 'app-testing-page',
  templateUrl: './testing-page.component.html',
  styleUrls: ['./testing-page.component.css']
})
export class TestingPageComponent implements OnInit, OnChanges {


  _itemPerBlock : number = 5;
  _testItems : TestItem[];

  _allSpecializations: ISpecialization[];
  _userId : string;

  constructor(private _specializationService : SpecializationService, 
              private _connectionService: ConnectionService,
              private _logic : LogicService) {
                this.processSpecialities = this.processSpecialities.bind(this);
                this.processSelectingDisciples = this.processSelectingDisciples.bind(this);
                this.processResponse = this.processResponse.bind(this);
               }

  ngOnInit() {
    this._specializationService.getSpecializations().subscribe(response => {
       this._userId = response.userId;
       this._allSpecializations = response.disciples;

       this._testItems = this._allSpecializations.map(element => {
        return new TestItem(element.id, element.label);
      })
    });

    this._connectionService.getReference().subscribe(this.processSpecialities);
  }

  ngOnChanges(){
  }


  private processSpecialities(formGroup: FormGroup) : void {
    this._logic.processSpecialization(this._allSpecializations, formGroup);
    let isAllSpecilizationShown = this._logic.isAllSpecilititesChecked(this._allSpecializations);
    if (isAllSpecilizationShown === true) {
      let items = new Map<number, number>();
      this._allSpecializations.forEach(element => 
        items[element.id] = element.weight);
        let sendData = new SendData(this._userId, items);
        this._specializationService.getDisciples(sendData).subscribe(this.processResponse);
        this._connectionService.getReference().unsubscribe();
        this._connectionService.recreateLink();
        this._connectionService.getReference().subscribe(this.processSelectingDisciples);
    }
    else {
    } 
  }

  private processResponse(response : any[]) {
    this._testItems = response.map(element => {
      return new TestItem(element.id, element.label);
    });
  }

  private processSelectingDisciples(formGroup : FormGroup) {
    let items = new Map<number, number>();
    let ids : number[] = [];

    ids = Object.keys(formGroup.controls).map(Number);

    ids.forEach(id => {
      items[id] = formGroup.controls[id].value;
    });

    let sendData = new SendData(this._userId, items);
    this._specializationService.getDisciples(sendData).subscribe(this.processResponse);
  }
}