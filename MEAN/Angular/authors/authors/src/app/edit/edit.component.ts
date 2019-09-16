import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';
import {FormBuilder} from '@angular/forms';
import {ActivatedRoute, Router, Params} from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
editForm;
message;
author;
  constructor(private httpService: HttpService, private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute) {
    this.route.params.subscribe((params:Params) => {
      this.httpService.getOne(params.id)
        .subscribe((author:any) =>  {
          if(author === null){
            this.router.navigate(['/error'])
          }
          this.editForm = this.formBuilder.group({
            name: author.name
          });
          this.author = author;
        });
      });
  }

  ngOnInit() {
  }

  onSubmit(formData){
    this.httpService.putAuthor(this.author._id,formData)
      .subscribe((msg:any) => {
        if(msg.success){
          this.router.navigate(['/home']);
        }
        else{
          this.message = msg;
        }
      });
  }

}
