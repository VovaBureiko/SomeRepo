export interface ISpecialization {
    id : number,
    label : string,
    isChecked : boolean,
    weight: number
}

export interface IDiscipleBlocks {
    id : number,
    label : string,
    score: number,
    specilaDepartamnt: number,
    isShown: boolean
}

export interface IDisciple {
    id : number,
    weight : number,
    isShown : boolean
}

export interface IDepartSpecila {
    id: number,
    specialId: number,
    departamnetId : number
}

export interface IAcademicDisciple {
    id: number,
    discpId : number,
    term: number,
    credit: number,
    score: number,
    pecialDepartment : number
}