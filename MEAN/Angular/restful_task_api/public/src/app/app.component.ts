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
  newTask: any;
  tasks: any;
  newErrors:any;
  editErrors:any;

  constructor(private _httpService: HttpService){}

  ngOnInit(){
    this.newTask = {title:"",description:""};
    this.getTasksFromService();
  }

  onSubmit(){
    let obs = this._httpService.postToServer(this.newTask);
    obs.subscribe(err => this.newErrors = err);
    this.getTasksFromService();
    this.newTask = {title:"",description:""};
  }

  getTasksFromService() {
    let observ = this._httpService.getTasks();
    observ.subscribe(data => {
        this.tasks = data;
      });
  }

  oneTask: any;
  getOneTaskFromService(id:string) {
    let observ = this._httpService.getOneTask(id);
    observ.subscribe(data => {
      this.oneTask = data;
    });
  }

  hideEdit(){
    this.oneTask = undefined;
  }

  deleteTask(id:string){
    let observ = this._httpService.delete(id);
    observ.subscribe(data => this.tasks = data);
  }
  updateTask(id:string){
    let obs = this._httpService.update(id,this.oneTask);
    obs.subscribe(err => this.editErrors = err);
    this.getTasksFromService();
  }

  onButtonClick(): void {
    console.log(`Click event is working`);
  }
  onButtonClickParam(num: Number): void { 
      console.log(`Click event is working with num param: ${num}`);
  }
  onButtonClickParams(num: Number, str: String): void { 
      console.log(`Click event is working with num param: ${num} and str param: ${str}`);
  }
  onButtonClickEvent(event: any): void { 
      console.log(`Click event is working with event: ${event}`);
  }

}