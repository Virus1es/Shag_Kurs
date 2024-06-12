import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";

// класс необходимый для общения с бэк приложением
@Injectable()
export class HttpService{
    constructor(private http: HttpClient){ }

    // получить с сервера данные по url(ссылке)
    getData(url: string){
        return this.http.get(url)
    }

    // передать запрос с параметром бэку
    getQuery01(goal: string){
        const params = new HttpParams().set("goal", goal);
        return this.http.get("http://localhost:5027/queries/Query01", {params});
    }
}
