import { Component, Input, OnChanges } from "@angular/core";
import { TestItem } from "../select-your-destiny/models/testItem";
import { FormGroup, FormBuilder} from '@angular/forms';
import { ConnectionService } from "src/app/services/testing.connection.service";

@Component({
    selector:'app-testing-area',
    templateUrl:'./testing-area.component.html'
})
export class TestingAreaComponent implements OnChanges {
    @Input() _testItems : TestItem[]
    formGroup: FormGroup;
    controlList: any;

    constructor(private _formBuilder: FormBuilder, private _connectionService: ConnectionService) {
        this.formGroup = _formBuilder.group([]);
        this.controlList = [];
    }

    ngOnChanges() {
        if (this._testItems) {
            this._testItems.forEach(element => {
                this.controlList[element.id] = '';
            });

            this.formGroup = this._formBuilder.group(this.controlList);
        }
    }

    onSubmit() : void {
        if (this.formGroup.valid) {
            this._connectionService.sendTestItterationResult(this.formGroup);
        }
    }
}