import { Component, OnInit } from '@angular/core';
import { SpecializationService } from '../../services/specializationService';
import { ISpecialization, IDiscipleBlocks, IDisciple, IAcademicDisciple, IDepartSpecila } from '../../models/specialization';
import { TestItem } from '../select-your-destiny/models/testItem';
import { ConnectionService } from 'src/app/services/testing.connection.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-testing-page',
  templateUrl: './testing-page.component.html',
  styleUrls: ['./testing-page.component.css']
})
export class TestingPageComponent implements OnInit {

  _itemPerBlock : number = 5;
  _testItems : TestItem[];

  _allSpecializations: ISpecialization[];
  _discipleBlocks : IDiscipleBlocks[];
  _disciples : Array<IDisciple[]>;
  _academicDisc : Array<IAcademicDisciple>[];
  _departamentSpec : Array<IDepartSpecila>[];
  _self: any;

  constructor(private _specializationService : SpecializationService, 
              private _connectionService: ConnectionService) {
                this.processSpecialities = this.processSpecialities.bind(this);
               }

  ngOnInit() {
    this._specializationService.getSpecializations().subscribe(response => {
       this._allSpecializations = response.specializationDTO;
       this._discipleBlocks = response.blocksDTO;
       this._disciples = response.disciples;
       this._academicDisc = response.academicDiscipleDTO;
       this._departamentSpec = response.departSpecialDTO;

       this._testItems = this._allSpecializations.map(element => {
        return new TestItem(element.id, element.label);
      })
    });

    this._connectionService.getReference().subscribe(this.processSpecialities);
  }


  private processSpecialities(formGroup: FormGroup) : void {
    this.processDisciples();
  }

  private processDisciples() {
    this._testItems = this._discipleBlocks.sort((first, second) => {
      return second.score - first.score;
    }).slice(0,4).map(element => {
      return new TestItem(element.id, element.label)
    });
  }


}