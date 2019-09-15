import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SeattleComponent } from './seattle/seattle.component';
import { BurbankComponent } from './burbank/burbank.component';
import { ChicagoComponent } from './chicago/chicago.component';
import { DallasComponent } from './dallas/dallas.component';
import { SanJoseComponent } from './san-jose/san-jose.component';
import { WashingtonDcComponent } from './washington-dc/washington-dc.component';
import { WeatherResolverService } from './weather-resolver.service';

const routes: Routes = [
  {path: 'seattle',component: SeattleComponent, data:{city:"seattle,wa"}, resolve: {weather: WeatherResolverService}},
  {path: 'burbank',component: BurbankComponent, data:{city:"burbank,ca"}, resolve: {weather: WeatherResolverService}},
  {path: 'chicago',component: ChicagoComponent, data:{city:"chicago,il"}, resolve: {weather: WeatherResolverService}},
  {path: 'dallas',component: DallasComponent, data:{city:"dallas,tx"}, resolve: {weather: WeatherResolverService}},
  {path: 'san-jose',component: SanJoseComponent, data:{city:"san jose,ca"}, resolve: {weather: WeatherResolverService}},
  {path: 'washington-dc',component: WashingtonDcComponent, data:{city:"washington,d.c"}, resolve: {weather: WeatherResolverService}},
  {path: '**',pathMatch: 'full',redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
