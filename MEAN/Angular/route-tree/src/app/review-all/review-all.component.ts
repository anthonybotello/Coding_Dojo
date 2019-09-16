import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-review-all',
  templateUrl: './review-all.component.html',
  styleUrls: ['./review-all.component.css']
})
export class ReviewAllComponent implements OnInit {
id;
constructor(private route: ActivatedRoute) {
  this.route.params.subscribe(params => {
    this.id = params.id;
  });
  }
  ngOnInit() {
  }

}
