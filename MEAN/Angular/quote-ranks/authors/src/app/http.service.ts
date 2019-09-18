import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  
  getAll(){
    return this.http.get('/authors');
  }
  getOne(id:string){
    return this.http.get(`/authors/${id}`);
  }
  postAuthor(formData){
    return this.http.post('/authors',formData);
  }
  deleteAuthor(id:string){
    this.http.delete(`/authors/${id}`)
      .subscribe();
  }
  putAuthor(id:string,formData){
    return this.http.put(`/authors/${id}`,formData);
  }
  postQuote(formData,authorid){
    return this.http.post(`/authors/${authorid}/quotes/`,formData);
  }
  putVote(id:string,quoteid:string,votes:object){
    return this.http.put(`/authors/${id}/quotes/${quoteid}`,votes);
  }
  deleteQuote(id:string,quoteid:string){
    return this.http.delete(`/authors/${id}/quotes/${quoteid}`);
  }
}
