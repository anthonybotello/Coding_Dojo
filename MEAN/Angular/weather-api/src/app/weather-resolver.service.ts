import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of, EMPTY } from 'rxjs';
import { take, mergeMap, catchError } from 'rxjs/operators';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherResolverService implements Resolve<any> {

  constructor(private _http: HttpService, private router: Router) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Observable<never> {
    const url = `http://api.openweathermap.org/data/2.5/weather?q=${route.data.city}.&units=imperial&appid=0bafe1fb01cd2072bfa966ed18c14451`;
    return this._http.getWeather(url).pipe(take(1), mergeMap(weather => {
          if (weather) {
             return of(weather);
          }
          else {
            this.router.navigate(['/']);
             return EMPTY;
          }
        })
      );
    }
}

