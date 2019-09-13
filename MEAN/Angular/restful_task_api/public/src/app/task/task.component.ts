import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  @Input() taskToShow: any;
  @Output() hideEditEmitter = new EventEmitter();
  @Output() editTaskEmitter = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  hideEdit(){
    this.hideEditEmitter.emit();
  }

  editTask(event,id:string){
    this.editTaskEmitter.emit(id);
  }

}
