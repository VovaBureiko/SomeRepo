import { Component, OnInit } from '@angular/core';
import { SpecializationService } from '../../services/specializationService';
import { ISpecialization, IDiscipleBlocks, IDisciple, IAcademicDisciple, IDepartSpecila } from '../../models/specialization';
import { TestItem } from '../select-your-destiny/models/testItem';
import { ConnectionService } from 'src/app/services/testing.connection.service';
import { FormGroup } from '@angular/forms';
import { LogicService } from 'src/app/services/logic';
import { Mapper } from 'src/app/models/mapper';

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
              private _connectionService: ConnectionService,
              private _logic: LogicService,
              private _mapper: Mapper) {
                this.processSpecialities = this.processSpecialities.bind(this);
                this.processDisciples = this.processDisciples.bind(this);
               }

  ngOnInit() {
    this._specializationService.getSpecializations().subscribe(response => {
       this._allSpecializations = response.specializationDTO.map(element => {
            return this._mapper.toSpecialization(element);
       });
       this._discipleBlocks = response.blocksDTO.map(element => {
         return this._mapper.toDiscipleBlock(element);
       });
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
    this._logic.processSpecialization(this._allSpecializations, formGroup);
    let isAllSpecilizationShown = this._logic.isAllSpecilititesChecked(this._allSpecializations);
    if (isAllSpecilizationShown === true) {
      this._connectionService.getReference().unsubscribe();
      this._connectionService.getReference().subscribe(this.processDisciples);
      this.firstDisciples();
    } 
  }

  private processDisciples(formGroup : FormGroup) {
    this._logic.setUpCheckedDisciples(this._discipleBlocks, formGroup);

    this._testItems = this._logic.getDisciplesBlocks(5, this._discipleBlocks).map(element => {
      return new TestItem(element.id, element.label);
    })
  }

  private firstDisciples(){
    this._testItems = this._logic.getDisciplesBlocks(5, this._discipleBlocks).map(element => {
      return new TestItem(element.id, element.label);
    })
  }
}