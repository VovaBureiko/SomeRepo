export class SendData {

    userId: string;
    userChoose: Map<number, number>

    constructor(userId : string, userChoose : Map<number, number>) {
        this.userId = userId;
        this.userChoose = userChoose;
    }
}