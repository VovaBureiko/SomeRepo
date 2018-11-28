import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { Observable } from "rxjs";
import { IRecievedData } from "../models/receivedData";

@Injectable()
export class SpecializationService {
    
    private _specialization = 'https://localhost:44356/api/test/specialization'
    
    constructor(private _http : HttpClient) {
    }


    public getSpecializations(): Observable<IRecievedData> {
        return this._http.get<IRecievedData>(this._specialization);
    }
}