import { Injectable } from "@angular/core";
import { ISpecialization, IDiscipleBlocks } from "../models/specialization";
import { FormGroup } from "@angular/forms";

@Injectable()
export class LogicService {
    
    processSpecialization(specializations: ISpecialization[], userSelected: FormGroup) {
        let ids = this.returnSpecializationIds(userSelected.controls);
        this.setUpCheckedFlag(specializations, ids);
        this.setUpChoosenValue(specializations, ids, userSelected);
    }

    private setUpCheckedFlag(specialization: ISpecialization[], shownIds: number[]) {
        for(var index of shownIds) {
            specialization.find(element => element.id == index).isChecked = true;
        }
    }

    private returnSpecializationIds(controls: any) : number[] {
        let ids : number[] = [];

        ids = Object.keys(controls).map(Number);

        return ids;
    }

    private setUpChoosenValue(specialization: ISpecialization[], ids: number[], formGroup: FormGroup) {
        ids.forEach(id => {
            specialization.find(spec => spec.id == id).weight = formGroup.controls[id].value;
        });
    }

    public isAllSpecilititesChecked(specialization: ISpecialization[]) : boolean {
        return specialization.every(spec => spec.isChecked)
    }
}