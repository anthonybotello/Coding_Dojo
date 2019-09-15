import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) {}
  getTasks(){
    return this._http.get('/tasks');
  }
  getOneTask(id:string){
    return this._http.get(`/tasks/${id}`);
  }
  postToServer(data){
    return this._http.post('/tasks',data);
    // .subscribe(err => console.log(err));
    // return this.getTasks();
  }
  delete(id:string){
    this._http.delete(`/tasks/${id}`)
    .subscribe();
    return this.getTasks();
  }
  update(id:string,data){
    return this._http.put(`/tasks/${id}`,data);
  }
}v