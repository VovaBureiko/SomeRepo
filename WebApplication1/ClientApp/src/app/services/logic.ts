import { Injectable } from "@angular/core";
import { ISpecialization } from "../models/specialization";
import { FormGroup } from "@angular/forms";

@Injectable()
export class Logic {
    
    processSpecialization(specializations: ISpecialization[], userSelected: FormGroup) {
        let ids = this.returnSpecializationIds(userSelected.controls);
        this.setUpCheckedFlag(specializations, ids);
    }

    private setUpCheckedFlag(specialization: ISpecialization[], shownIds: number[]) {
        for(var index in shownIds) {
            specialization[index].isChecked = true;
        }
    }

    private returnSpecializationIds(controls: any) : number[] {
        let ids : number[] = [];

        ids = Object.keys(controls).map(Number);

        return ids;
    }

    private setUpChoosenValue(specialization: ISpecialization[], ids: number[]) {
        ids.forEach(id => {
            specialization.find(spec => spec.id == id).
        })
    }
}