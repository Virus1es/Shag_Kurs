import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {CurrencyPipe, DatePipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../../http.service";
import {Trip} from "../../Models/Trip";

@Component({
  selector: 'app-query04',
  standalone: true,
  imports: [
      RouterLink,
      CurrencyPipe,
      DatePipe,
      HttpClientModule
  ],
  templateUrl: './query04.component.html',
  styleUrl: './query04.component.css',
    providers: [HttpService]
})
export class Query04Component implements OnInit {

    // список чисел пришедших от ASP после выполнения запроса
    public rez: Array<number> = [];
    constructor(private http: HttpService){}

    // получить с бэка все записи о поездках в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/queries/Query04')
            .subscribe({next: (data: any) => this.rez = data});
    }
}
