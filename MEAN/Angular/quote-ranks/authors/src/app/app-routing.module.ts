import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {NewComponent} from './new/new.component';
import {EditComponent} from './edit/edit.component';
import {AuthorComponent} from './author/author.component';
import {AuthorErrorComponent} from './author-error/author-error.component';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {path:'new',component: NewComponent},
  {path:'edit/:id', component: EditComponent},
  {path: 'author/:id', component: AuthorComponent},
  {path: 'error', component: AuthorErrorComponent},
  {path:'**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
