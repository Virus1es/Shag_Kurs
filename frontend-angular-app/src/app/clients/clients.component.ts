import {Component, OnInit} from '@angular/core';
import {RouterLink} from "@angular/router";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {Client} from "../Models/Client";
import {HttpService} from "../http.service";

@Component({
    selector: 'app-clients',
    standalone: true,
    imports: [
        RouterLink,
        HttpClientModule
    ],
    templateUrl: './clients.component.html',
    styleUrl: './clients.component.css',
    providers: [HttpService]
})
export class ClientsComponent implements OnInit{

    // список клиентов пришедших от ASP
    clients: Array<Client> = [];

    constructor(private http: HttpService){}

    // получить с бэка все записи о клиентах в БД
    ngOnInit(): void {

        this.http.getData('http://localhost:5027/clients/get')
                 .subscribe({next: (data: any) => this.clients=data});
    }
}
