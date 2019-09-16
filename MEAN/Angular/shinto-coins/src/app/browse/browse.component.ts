import { Component, OnInit } from '@angular/core';
import {ShintoCoinsService} from '../shinto-coins.service';

@Component({
  selector: 'app-browse',
  templateUrl: './browse.component.html',
  styleUrls: ['./browse.component.css']
})
export class BrowseComponent implements OnInit {
ledger;
  constructor(private _coins: ShintoCoinsService) { }

  ngOnInit() {
    this.ledger = this._coins.getTrans();
    console.log(this.ledger);
  }

}
