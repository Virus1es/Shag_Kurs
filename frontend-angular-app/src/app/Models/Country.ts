// класс необходимый для получения и вывода данных о Странах
export class Country{
    constructor(public id: number, public countryName:string, public transportPrice:number,
                public visaPrice:number, public pricePerDay:number){}
}
