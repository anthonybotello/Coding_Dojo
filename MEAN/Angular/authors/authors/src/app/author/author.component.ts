import { Component, OnInit } from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {HttpService} from '../http.service';
import {ActivatedRoute, Params, Router} from '@angular/router';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
quoteForm;
message;
author;

  constructor(private httpService: HttpService, private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router) {
    this.quoteForm = this.formBuilder.group({
      quote:''
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
}
