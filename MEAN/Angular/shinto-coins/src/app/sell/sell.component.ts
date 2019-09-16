import { Component, OnInit } from '@angular/core';
import {FormBuilder} from '@angular/forms';
import { ShintoCoinsService } from '../shinto-coins.service';


@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {
coins;
sellForm;
nope;
  constructor(private formBuilder: FormBuilder,private _coins: ShintoCoinsService) {
    this.sellForm = this.formBuilder.group({
      minusCoins: '',
    });
    }

  ngOnInit() {
    this.coins = this._coins.getCoins();
  }

  onSubmit(formData){
    if(formData.minusCoins === "" || formData.minusCoins === null){
      formData.minusCoins = 1;
    }
    if(this.coins === 0){
      this.nope = "You don't have any coins to sell!";
    }
    else{
      if(this.coins - formData.minusCoins < 0){
        this.nope = "You don't have that many coins to sell!";
      }
      else{
        this.coins = this._coins.sell(parseInt(formData.minusCoins));
        this.sellForm.reset();
      }
    }
  }
}
