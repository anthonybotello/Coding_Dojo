import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';
import {FormBuilder} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
authorForm;
message;
  constructor(private httpService: HttpService, private formBuilder: FormBuilder,private router: Router) {
    this.authorForm = this.formBuilder.group({
      name:''
    });
   }

  ngOnInit() {
  }

  onSubmit(formData){
    this.httpService.postAuthor(formData)
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
