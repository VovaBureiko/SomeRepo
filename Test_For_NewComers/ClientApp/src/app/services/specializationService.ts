import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ISpecialization } from "../models/specialization";

@Injectable()
export class SpecializationService implements OnInit{
    
    private _specializations : ISpecialization[];
    private _specialization = 'https://localhost:44343/api'
    constructor(private _http : HttpClient) {
    }
    
    ngOnInit() {
        this._http.get<ISpecialization[]>(this._specialization)
        .toPromise()
        .then(response => {
            this._specializations = response
        });
    }
}