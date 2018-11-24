export class TestItem {
    id: number;
    label: string;
    selectedOption : number;

    constructor(_id: number, _label : string) {
         this.id = _id;
         this.label = _label
    }
}