import { Component, OnInit, Input, Output } from '@angular/core';
import { HttpService } from './http.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = "Rate My Cakes";
  cakeForm;
  cakes;
  cakeErrors;
  ratingForm;
  ratingErrors;
  displayedCake;
  constructor(
    private _httpService:HttpService,
    private formBuilder: FormBuilder
    ){
      this.cakeForm = this.formBuilder.group({
        baker:'',
        image:''
      });
      this.ratingForm = this.formBuilder.group({
        cakeid:'',
        rating:'',
        comment:''
      });
    }
  ngOnInit(){
    this.allCakes();
  }
  
  onSubmitCake(cakeData){
    this._httpService.postCake(cakeData)
      .subscribe((msg: any) => {
        if(msg.success){
          this.cakeForm.reset();
          this.cakes = this.allCakes();
        }
          this.cakeErrors = msg;
      });
  }
  onSubmitRating(ratingData,_cakeid){
    ratingData.cakeid = _cakeid;
    this._httpService.postRating(ratingData)
      .subscribe((msg:any) => {
        if(msg.success){
          this.ratingForm.reset();
          this.displayedCake = this.getCake(_cakeid);
        }
        this.ratingErrors = msg;
      });
  }

  allCakes(){
    this._httpService.getCakes()
      .subscribe(_cakes => this.cakes = _cakes);
  }

  getCake(id:string){
    this._httpService.getCake(id)
      .subscribe(cake => this.displayedCake = cake);
  }
}
