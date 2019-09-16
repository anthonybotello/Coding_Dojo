import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-review-details',
  templateUrl: './review-details.component.html',
  styleUrls: ['./review-details.component.css']
})
export class ReviewDetailsComponent implements OnInit {
id;
constructor(private route: ActivatedRoute) {
  this.route.params.subscribe(params => {
    this.id = params.id;
  });
  }

  ngOnInit() {
  }

}
