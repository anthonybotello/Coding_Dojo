import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ListComponent} from './list/list.component';
import {NewComponent} from './new/new.component';
import {EditComponent} from './edit/edit.component';
import {ProductsComponent} from './products/products.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'products', component: ProductsComponent, children:[
    {path:'', component: ListComponent},
    {path:'edit/:id', component: EditComponent},
    {path: 'new', component: NewComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
