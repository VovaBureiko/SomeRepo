import { Injectable } from "@angular/core";
import { ISpecialization, IDiscipleBlocks } from "../models/specialization";
import { FormGroup } from "@angular/forms";

@Injectable()
export class LogicService {
    
    processSpecialization(specializations: ISpecialization[], userSelected: FormGroup) {
        let ids = this.returnSpecializationIds(userSelected.controls);
        this.setUpCheckedFlag(specializations, ids);
        this.setUpChoosenValue(specializations, ids);
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

    private setUpChoosenValue(specialization: ISpecialization[], ids: number[]) {
        ids.forEach(id => {
            specialization.find(spec => spec.id == id).isChecked = true;;
        });
    }

    public isAllSpecilititesChecked(specialization: ISpecialization[]) : boolean {
        return specialization.every(spec => spec.isChecked)
    }

    public setUpCheckedDisciples(blockId : IDiscipleBlocks[], userSelectd: FormGroup) {
        let ids = this.returnSpecializationIds(userSelectd);
        this.setUpChoosenValueForBlocks(blockId, ids);
    }

    private setUpChoosenValueForBlocks(blocks: IDiscipleBlocks[], ids: number[]) {
        ids.forEach(id => blocks.find(block => block.id == id).isShown = true);
    }

    public getDisciplesBlocks(count: number, disciples : IDiscipleBlocks[]) : IDiscipleBlocks[] {
       return disciples.sort((first, second) => {
            if (first.isShown == true) {
                return -1;
            }

            if (second.isShown == true) {
                return 1;
            }
        }).sort((first, second) => {
            return second.score - first.score}).slice(0, count - 1);
    }
}