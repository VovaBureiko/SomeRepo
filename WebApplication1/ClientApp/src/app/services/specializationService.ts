import { Injectable } from "@angular/core";
import { HttpClient, HttpParams} from '@angular/common/http';
import { Observable, Subject } from "rxjs";
import { SendData } from "../models/prepearingData";
import { IRecievedData } from "../models/receivedData";

@Injectable()
export class SpecializationService {
    
    private _specialization = 'https://localhost:44356/api/test/specialization';
    private _disciples = 'https://localhost:44356/api/test/disciples'
    private _result = 'https://localhost:44356/api/endtest/result';
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

    public getFinalResult(userId: string) {
        return this._http.get<any>(this._result, {params: new HttpParams().set('userId', userId)});
    }
}