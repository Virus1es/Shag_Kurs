import { RouterLinkWithHref, RouterModule, RouterOutlet, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {TripsComponent} from "./trips/trips.component";
import {RoadsComponent} from "./roads/roads.component";
import {ClientsComponent} from "./clients/clients.component";
import {GoalsComponent} from "./goals/goals.component";
import {CountriesComponent} from "./countries/countries.component";
import {Query04Component} from "./queries/query04/query04.component";
import {Query05Component} from "./queries/query05/query05.component";
import {Query01Component} from "./queries/query01/query01.component";
import {Query02Component} from "./queries/query02/query02.component";
import {Query03Component} from "./queries/query03/query03.component";

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'trips', component: TripsComponent},
    {path: 'roads', component: RoadsComponent},
    {path: 'clients', component: ClientsComponent},
    {path: 'goals', component: GoalsComponent},
    {path: 'countries', component: CountriesComponent},
    {path: 'query01', component: Query01Component},
    {path: 'query02', component: Query02Component},
    {path: 'query03', component: Query03Component},
    {path: 'query04', component: Query04Component},
    {path: 'query05', component: Query05Component},
];

