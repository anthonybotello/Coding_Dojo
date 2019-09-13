import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css'
]
})
export class AppComponent implements OnInit {
  title = 'RESTful Tasks API';

  constructor(private _httpService: HttpService){}

  ngOnInit(){
    this.getTasksFromService();
    this.getOneTaskFromService("5d7ae5c32e143118b7ec4eff");
  }

  tasks: any;
  getTasksFromService(){
    let observ = this._httpService.getTasks();
    observ.subscribe(data => {
        console.log("Yep, yep, yep!",data);
        this.tasks = data;
      });
  }

  oneTask: any;
  getOneTaskFromService(id:string){
    let observ = this._httpService.getOneTask(id);
    observ.subscribe(data => {
      console.log("Mhmm.",data);
      this.oneTask = data;
    });
  }
}