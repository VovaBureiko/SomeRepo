import { Injectable } from "@angular/core";
import { Subject } from "rxjs";
import { FormGroup } from "@angular/forms";

@Injectable()
export class ConnectionService {

    private _resultSubject : Subject<FormGroup>;

    getReference() : Subject<FormGroup> {
        return this._resultSubject;
    }
    
    constructor() {
        this._resultSubject = new Subject<FormGroup>();
    }

    sendTestItterationResult(formGroup: FormGroup) {
        this._resultSubject.next(formGroup);
    }

    recreateLink() {
        this._resultSubject = new Subject<FormGroup>();
    }
}