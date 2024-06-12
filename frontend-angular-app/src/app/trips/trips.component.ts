import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {CurrencyPipe, DatePipe} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import {HttpService} from "../http.service";
import {Trip} from "../Models/Trip";

@Component({
  selector: 'app-trips',
  standalone: true,
    imports: [
        RouterLink,
        CurrencyPipe,
        DatePipe,
        HttpClientModule
    ],
  templateUrl: './trips.component.html',
  styleUrl: './trips.component.css',
    providers: [HttpService]
})
export class TripsComponent implements OnInit {

    // список поездок пришедших от ASP
    public trips: Array<Trip> = [];
    constructor(private http: HttpService){}

    // получить с бэка все записи о поездках в БД
    ngOnInit(): void {
        this.http.getData('http://localhost:5027/trips/get')
            .subscribe({next: (data: any) => this.trips = data});
    }
}
