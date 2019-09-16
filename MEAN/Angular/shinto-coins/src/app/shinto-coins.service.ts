import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ShintoCoinsService {
shintoCoins = 0;
transactions = [];
  constructor() { }
transID = 0;
 newTrans(act:string, val:number){
   this.transID++;
  this.transactions.push({
    id:this.transID,
    action: act,
    value: val,
    desc: `${act} ${val} coin(s).`
  });
 }
mine(){
  this.newTrans("Mined",1);
  return this.shintoCoins++;
}
buy(plusCoins){
  this.newTrans("Bought",plusCoins);
  return this.shintoCoins += plusCoins;
}
sell(minusCoins){
  this.newTrans("Sold",minusCoins);
  return this.shintoCoins -= minusCoins;
}
getCoins(){
  return this.shintoCoins;
};
getTrans(){
  return this.transactions;
}
}
