import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.css']
})
export class ProductCategoryComponent implements OnInit {
cat;
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.cat = params.cat;
    })
   }

  ngOnInit() {
  }

}
