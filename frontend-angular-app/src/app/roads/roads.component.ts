import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {CurrencyPipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../http.service";
import {Road} from "../Models/Road";

@Component({
  selector: 'app-roads',
  standalone: true,
    imports: [
        RouterLink,
        CurrencyPipe,
        HttpClientModule
    ],
  templateUrl: './roads.component.html',
  styleUrl: './roads.component.css',
    providers: [HttpService]
})
export class RoadsComponent implements OnInit {

    // список маршрутов пришедших от ASP
    roads: Array<Road> = [];
    constructor(private http: HttpService){}

    // получить с бэка все записи о маршрутах в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/roads/get')
            .subscribe({next: (data: any) => this.roads=data});
    }
}
