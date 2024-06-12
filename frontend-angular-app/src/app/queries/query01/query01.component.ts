import {Component, Input, OnInit} from '@angular/core';
import {CurrencyPipe} from "@angular/common";
import {RouterLink} from "@angular/router";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../../http.service";
import {Road} from "../../Models/Road";

@Component({
  selector: 'app-query01',
  standalone: true,
    imports: [
        RouterLink,
        CurrencyPipe,
        HttpClientModule
    ],
  templateUrl: './query01.component.html',
  styleUrl: './query01.component.css',
    providers: [HttpService]
})
export class Query01Component implements OnInit{
    @Input() goal : string = '';

    // список маршрутов пришедших от ASP
    roads: Array<Road> = [];
    constructor(private http: HttpService){}

    // получить с бэка все записи о маршрутах в БД
    ngOnInit(): void {
        this.http.getQuery01(this.goal).subscribe({next:(data:any) => {
                this.roads=data.result;
            }});
    }
}
