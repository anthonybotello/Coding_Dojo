import { Component, OnInit, Input, Output } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import {MatIconRegistry} from '@angular/material/icon';

@Component({
  selector: 'app-cake',
  templateUrl: './cake.component.html',
  styleUrls: ['./cake.component.css']
})
export class CakeComponent implements OnInit {
  @Input() showCake;

  setStars(numStars:number){
    var stars = [];
    for(let i = 1; i <= numStars; i++){
      stars.push(i);
    }
    return stars;
  }
  notStars(numStars:number){
    var notStars = [];
    for(let i = 1; i <= 5-numStars; i++){
      notStars.push(i);
    }
    return notStars;
  }

  avgRating(){
    var len = this.showCake.ratings.length;
    var avg = 0;
    this.showCake.ratings.forEach(r => {
      avg += (r.rating/len) 
    });
    return avg;
  }
  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon(
        'thumbs-up',
        sanitizer.bypassSecurityTrustResourceUrl('assets/img/examples/thumbup-icon.svg')); 
      }

  ngOnInit() {
  }

}
