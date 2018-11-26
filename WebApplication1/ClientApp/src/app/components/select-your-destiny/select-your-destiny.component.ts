import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-select-your-destiny',
  templateUrl: './select-your-destiny.component.html',
  styleUrls: ['./select-your-destiny.component.scss']
})
export class SelectYourDestinyComponent {

  @Input() Label : string;
  @Input() _name: string
  @Input() _formGroup : FormGroup

  public get returnCurrentId() : string{
    return this._name;
  }

  public get returnFormGroup() : FormGroup {
      return this._formGroup;
  }

  constructor(private _formBuilder: FormBuilder) {
 
  }
}
