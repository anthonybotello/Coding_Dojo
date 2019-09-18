import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
authors;
  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.httpService.getAll()
      .subscribe(authors => this.authors = authors);
  }

  deleteAuthor(id:string){
    this.httpService.deleteAuthor(id);
    this.httpService.getAll()
      .subscribe(authors => this.authors = authors);
  }
}
