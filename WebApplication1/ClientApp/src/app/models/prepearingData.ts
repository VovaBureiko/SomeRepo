import { ISpecialization, IDiscipleBlocks, IDisciple, IDepartSpecila, IAcademicDisciple } from "./specialization";

export class PrepearData {

    specializations: Array<ISpecialization>

    discipleBlocks: Array<IDiscipleBlocks>

    disciples: Array<IDisciple>

    discipleSpecial: Array<IDepartSpecila>

    academicDiscl: Array<IAcademicDisciple>

    constructor(
        spec: Array<ISpecialization>,
        discBlock: Array<IDiscipleBlocks>,
        disc : Array<IDisciple>,
        discSpecl: Array<IDepartSpecila>,
        academ: Array<IAcademicDisciple>) {
            this.specializations = spec;
            this.discipleBlocks = discBlock,
            this.disciples = disc,
            this.discipleSpecial = discSpecl,
            this.academicDiscl = academ
    }
}