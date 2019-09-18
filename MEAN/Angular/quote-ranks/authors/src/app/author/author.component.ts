import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, Validators, ValidationErrors} from '@angular/forms';
import {HttpService} from '../http.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import {MatIconRegistry} from '@angular/material/icon';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
quoteForm;
message;
author;

  static notBlank(control: FormControl): ValidationErrors{
    if(control.value.trim() === ''){
      return {blank: true}
    }
    else{
      return null;
    }
  }

  constructor(private httpService: HttpService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router,iconRegistry:MatIconRegistry,domSanitizer:DomSanitizer) {
    this.quoteForm = this.formBuilder.group({
      quote: new FormControl('',[
        Validators.required      
      ])
    });
    this.route.params.subscribe((params:Params) => {
      this.httpService.getOne(params.id)
        .subscribe(author => {
          if (author === null){
            this.router.navigate(['/error']);
          }
          this.author = author
        });
    });
   }

  ngOnInit() {
  }

  onSubmit(formData,authorid){
    this.httpService.postQuote(formData,authorid)
      .subscribe((msg:any) => {
        if(msg.success){
          this.message = undefined;
          this.httpService.getOne(this.author._id)
            .subscribe(author => this.author = author);
          this.quoteForm.reset();
        }
        else{
          this.message = msg;
        }
      })
  }

  quoteVote(quoteid:string,votes:number){
    this.httpService.putVote(this.author._id,quoteid,{votes:votes})
      .subscribe(() => {
        this.httpService.getOne(this.author._id)
          .subscribe(author => this.author = author);
      });
  }
  quoteDelete(quoteid:string){
    this.httpService.deleteQuote(this.author._id,quoteid)
      .subscribe(() => {
        this.httpService.getOne(this.author._id)
          .subscribe(author => this.author = author);
      });
  }

  get quote() {
    return this.quoteForm.get('quote');
  }
}
