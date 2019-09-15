import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'weather-api';
  cities = [
    {name:"Seattle, WA",route:['/seattle']},
    {name:"San Jose, CA",route:['/san-jose']},
    {name:"Burbank, CA",route:['/burbank']},
    {name:"Dallas, TX",route:['/dallas']},
    {name:"Washington, D.C.",route:['/washington-dc']},
    {name:"Chicago, IL",route:['/chicago']}
  ]
  weather;

  constructor(
    private router: Router,
    private _httpService: HttpService
    ){}

  ngOnInit(){
    this.router.navigate(['/seattle']);
  }

  // getWeatherFromService(city:string){
  //   this._httpService.getWeather(city)
  //     .subscribe(data => console.log(data));
  // }

}
