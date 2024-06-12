import {Component, OnInit} from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {CurrencyPipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "./http.service";
import {Goal} from "./Models/Goal";
import {Query01Component} from "./queries/query01/query01.component";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-root',
  standalone: true,
    imports: [RouterOutlet, RouterLink, RouterLinkActive, HttpClientModule,
              Query01Component, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
    providers: [HttpService]
})
export class AppComponent implements OnInit{
    title = 'Туристическое агентство';
    // список целей поездки пришедших от ASP
    goals: Array<Goal> = [];
    constructor(private http: HttpService){}

    public goalName: string = ''


    // получить с бэка все записи о целях поездки в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/goals/get')
            .subscribe({next: (data: any) => this.goals=data});
    }
}
