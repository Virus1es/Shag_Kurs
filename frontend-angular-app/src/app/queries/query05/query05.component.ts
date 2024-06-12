import { Component } from '@angular/core';
import {RouterLink} from "@angular/router";
import {CurrencyPipe, DatePipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../../http.service";

@Component({
  selector: 'app-query05',
  standalone: true,
  imports: [
      RouterLink,
      CurrencyPipe,
      DatePipe,
      HttpClientModule
  ],
  templateUrl: './query05.component.html',
  styleUrl: './query05.component.css',
    providers: [HttpService]
})
export class Query05Component {
    // список чисел пришедших от ASP после выполнения запроса
    public rez: number = 0.0;
    constructor(private http: HttpService){}

    // получить с бэка все записи о поездках в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/queries/Query05')
            .subscribe({next: (data: any) => this.rez = data});
    }
}
