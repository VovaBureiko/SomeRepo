import { ISpecialization, IDiscipleBlocks } from "./specialization";
import { Injectable } from "@angular/core";

@Injectable()
export class Mapper {

    public toSpecialization(specialization : any) : ISpecialization {
        return {
            id: specialization.id,
            label : specialization.label,
            isChecked: false,
            weight: specialization.weight
        }
    }

    public toDiscipleBlock(block: any) : IDiscipleBlocks {
        return {
            id : block.id,
            label : block.label,
            score : block.score,
            specilaDepartamnt : block.SpecialDepartment
        }
    }
}