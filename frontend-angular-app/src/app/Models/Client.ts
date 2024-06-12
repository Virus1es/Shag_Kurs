// класс необходимый для получения и вывода данных о Клиентах
export class Client{
    constructor(public id: number, public name:string, public surname:string,
                public patronymic:string, public passport:string){}
}
