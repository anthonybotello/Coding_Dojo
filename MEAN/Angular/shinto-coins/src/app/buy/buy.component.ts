import { Component, OnInit } from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {ShintoCoinsService} from '../shinto-coins.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {
coins;
buyForm;
  constructor(private formBuilder: FormBuilder, private _coins: ShintoCoinsService) {
    this.buyForm = this.formBuilder.group({
      plusCoins: '',
    });
   }

  ngOnInit() {
    this.coins = this._coins.getCoins();
  }

  onSubmit(formData){
    if(formData.plusCoins === "" || formData.plusCoins === null){
      formData.plusCoins = 1;
    }
    this.coins = this._coins.buy(parseInt(formData.plusCoins));
    this.buyForm.reset();
  }

}
