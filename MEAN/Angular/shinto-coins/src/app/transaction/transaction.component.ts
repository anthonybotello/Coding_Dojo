import { Component, OnInit } from '@angular/core';
import {ActivatedRoute,Params,Router} from '@angular/router';
import {ShintoCoinsService} from '../shinto-coins.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
trans;
  constructor(private route: ActivatedRoute, private router:Router,private _coins: ShintoCoinsService) { }

  ngOnInit() {
    this.route.params.subscribe((params:Params) => {
      if(this._coins.getTrans()[params.id - 1]){
        this.trans = this._coins.getTrans()[params.id - 1];
      }
      else
      {
        this.router.navigate(['/home']);
      }
    });
  }

}
