// класс необходимый для получения и вывода данных о Маршрутах
import {Country} from "./Country";
import {Goal} from "./Goal";

export class Road{
    constructor(public id: number, public idCountry:number, public country:Country,
                public idGoal:number, public goal:Goal){}

    // итоговая сумма 1 дня пребывания в стране
    // TODO: разобраться почему не работает (road_r1.getRezPricePerDay is not a function)
    public getRezPricePerDay(): number {
        return this.country.pricePerDay + this.goal.pricePerDay;
    }
}
