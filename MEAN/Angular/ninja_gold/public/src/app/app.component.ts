import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Ninja Gold';
  game;

  constructor(private _httpService: HttpService){}

  ngOnInit(){
    let obs = this._httpService.newGame();
    obs.subscribe(_game => this.game = _game);
  }

  playerAction(choice:string){
    function randInt(min, max) {
      return Math.floor(Math.random() * (max - min) ) + min;
    }
    const choices = {
      farm: randInt(10,20),
      cave: randInt(5,10),
      house: randInt(2,5),
      casino: randInt(0,50)
    }
    var data = {id:this.game._id};
    var deltaGold = choices[choice];
    if (choice === 'casino'){
      if(Math.floor(Math.random() * 2) === 0){
        data['gold'] = deltaGold * -1;
        data['activity'] = {event:`Lost ${deltaGold} gold at the casino!`,color:'red'};
      }
      else{
        data['gold'] = deltaGold;
        data['activity'] = {event:`Won ${deltaGold} gold at the casino!`,color:'green'};
      }
    }
    else{
      data['gold'] = deltaGold;
      data['activity'] = {event:`Earned ${deltaGold} gold from the ${choice}.`,color:'green'};
    }

    let obs = this._httpService.updateGame(data);
    obs.subscribe(_game => this.game = _game);
  }
}
