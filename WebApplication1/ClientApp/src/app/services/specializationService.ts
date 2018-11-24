import { Injectable, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ISpecialization } from "../models/specialization";

@Injectable()
export class SpecializationService {
    
    private _specialization = 'https://localhost:44356/api/test/specialization'
    private headers = new HttpHeaders();
    private httpOptions;
    
    constructor(private _http : HttpClient) {
        this.headers = this.headers.set('Content-Type', 'application/json; charset=utf-8');
        this.httpOptions = {headers : this.headers}
    }


    public getSpecializations(): Promise<ISpecialization[]> {
        console.log(1);
        return this._http.get<ISpecialization[]>(this._specialization).toPromise();
    }
}