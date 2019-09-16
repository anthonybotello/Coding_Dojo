import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-review-author',
  templateUrl: './review-author.component.html',
  styleUrls: ['./review-author.component.css']
})
export class ReviewAuthorComponent implements OnInit {
id;
constructor(private route: ActivatedRoute) {
  this.route.params.subscribe(params => {
    this.id = params.id;
  });
  }

  ngOnInit() {
  }

}
