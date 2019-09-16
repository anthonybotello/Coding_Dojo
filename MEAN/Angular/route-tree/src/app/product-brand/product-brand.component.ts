import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-product-brand',
  templateUrl: './product-brand.component.html',
  styleUrls: ['./product-brand.component.css']
})
export class ProductBrandComponent implements OnInit {
brand;
  constructor(private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.brand = params.brand;
    });
   }

  ngOnInit() {
  }

}
