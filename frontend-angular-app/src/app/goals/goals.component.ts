import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {CurrencyPipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../http.service";
import {Goal} from "../Models/Goal";

@Component({
  selector: 'app-goals',
  standalone: true,
    imports: [
        RouterLink,
        CurrencyPipe,
        HttpClientModule
    ],
    templateUrl: './goals.component.html',
    styleUrl: './goals.component.css',
    providers: [HttpService]
})
export class GoalsComponent implements OnInit {
    // список целей поездки пришедших от ASP
    goals: Array<Goal> = [];
    constructor(private http: HttpService){}

    // получить с бэка все записи о целях поездки в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/goals/get')
            .subscribe({next: (data: any) => this.goals=data});
    }
}
