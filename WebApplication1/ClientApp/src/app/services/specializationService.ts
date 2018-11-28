import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Observable, Subject } from "rxjs";
import { SendData } from "../models/prepearingData";
import { IRecievedData } from "../models/receivedData";

@Injectable()
export class SpecializationService {
    
    private _specialization = 'https://localhost:44356/api/test/specialization';
    private _disciples = 'https://localhost:44356/api/test/disciples'
    private _disciplesLink : Subject<any>;

    public get getDisciplesLink() {
        return this._disciplesLink;
    }

    constructor(private _http : HttpClient) {
        this._disciplesLink = new Subject();
    }


    public getSpecializations(): Observable<IRecievedData> {
        return this._http.get<IRecievedData>(this._specialization);
    }

    public getDisciples(sendData: SendData) {
         return this._http.post<any>(this._disciples, sendData);
    }
}