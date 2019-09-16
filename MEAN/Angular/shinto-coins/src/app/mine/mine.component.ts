import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ShintoCoinsService } from '../shinto-coins.service';

@Component({
  selector: 'app-mine',
  templateUrl: './mine.component.html',
  styleUrls: ['./mine.component.css']
})

export class MineComponent implements OnInit {
n;
mineForm;
wrong;
correct;
  constructor(private formBuilder: FormBuilder, private _coins: ShintoCoinsService) {
    this.mineForm = this.formBuilder.group({
      answer:''
    });
    this.n = Math.floor(Math.random() * 25);
  }

  ngOnInit() {
    this.n = Math.floor(Math.random() * 25);
  }

  onSubmit(formData){
    if (parseInt(formData.answer) === this.fibonacci(this.n)){
      this.wrong = undefined;
      this.correct = "You mined a new coin!";
      this._coins.mine();
      this.n = Math.floor(Math.random() * 25);
      this.mineForm.reset();
    }
    else{
      this.correct = undefined;
      this.wrong = "Try again.";
    }
  }
  fibonacci(m:number){
    if(m === 0 || m === 1){
      return m;
    }
    return this.fibonacci(m - 1) + this.fibonacci(m - 2);
  }
  getOrdinal(n){
    var s=["th","st","nd","rd"],
        v=n%100;
    return n+(s[(v-20)%10]||s[v]||s[0]);
 }
}
