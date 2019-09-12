import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) {
    this.getTasks();
    this.getOneTask("5d7a8c7a9f0104017634e3cf");
    this.getOneTask("5d7a8ca29f0104017634e3d0");
  }
  getTasks(){
    let tempObservable = this._http.get('/tasks');
    tempObservable.subscribe(data => console.log("Got our tasks!",data));
  }
  getOneTask(id:string){
    let tempObservable = this._http.get(`/tasks/${id}`);
    tempObservable.subscribe(data => console.log("Got task!", data));
  }

}
