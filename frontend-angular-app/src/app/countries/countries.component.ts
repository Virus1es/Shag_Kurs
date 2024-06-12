import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {HttpService} from "../http.service";
import {Country} from "../Models/Country";
import {CurrencyPipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";

@Component({
  selector: 'app-countries',
  standalone: true,
    imports: [
        RouterLink,
        CurrencyPipe,
        HttpClientModule
    ],
  templateUrl: './countries.component.html',
  styleUrl: './countries.component.css',
    providers: [HttpService]
})
export class CountriesComponent implements OnInit {

    // список стран пришедших от ASP
    countries: Array<Country> = [];

    constructor(private http: HttpService){}

    // получить с бэка все записи о странах в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/countries/get')
            .subscribe({next: (data: any) => this.countries=data});
    }
}
