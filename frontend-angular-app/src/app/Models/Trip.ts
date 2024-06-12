import {Client} from "./Client";
import {Road} from "./Road";

export class Trip{
    public id!: number; public dateStart!:Date; public daysAmount!: number; public idRoad!:number;
    public road!:Road; public idClient!:number; public client!:Client;

    constructor(id: number, dateStart:Date, daysAmount: number, idRoad:number,
                road:Road, idClient:number, client:Client){}

    // итоговая сумма поездки
    // TODO: разобраться почему не работает (road_r1.getRezPrice is not a function)
    getRezPrice() {
        return (this.road.country.pricePerDay + this.road.goal.pricePerDay) * this.daysAmount +
            this.road.country.transportPrice + this.road.country.visaPrice;
    }

    // вывод ФИО клиента
    getClientFullname() {
        return `${this.client.surname} ${this.client.name[0]}. ${this.client.patronymic[0]}`;
    }
}
