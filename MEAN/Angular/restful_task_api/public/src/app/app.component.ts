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
  }

  tasks: any;
  getTasksFromService() {
    let observ = this._httpService.getTasks();
    observ.subscribe(data => {
        console.log("Yep, yep, yep!",data);
        this.tasks = data;
      });
  }

  oneTask: any;
  getOneTaskFromService(id:string) {
    let observ = this._httpService.getOneTask(id);
    observ.subscribe(data => {
      console.log("Mhmm.",data);
      this.oneTask = data;
    });
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