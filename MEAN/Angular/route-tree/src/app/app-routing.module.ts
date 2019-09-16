import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProductComponent} from './product/product.component';
import {ProductDetailsComponent} from './product-details/product-details.component';
import {ProductBrandComponent} from './product-brand/product-brand.component';
import {ProductCategoryComponent} from './product-category/product-category.component';
import {ReviewComponent} from './review/review.component';
import {ReviewDetailsComponent} from './review-details/review-details.component';
import {ReviewAuthorComponent} from './review-author/review-author.component';
import {ReviewAllComponent} from './review-all/review-all.component';


const routes: Routes = [
  {path:'products',component:ProductComponent, children:[
    {path:'details/:id',component:ProductDetailsComponent},
    {path:'brand/:brand',component:ProductBrandComponent},
    {path:'category/:cat',component:ProductCategoryComponent}
  ]
  },
  {path:'reviews', component:ReviewComponent, children:[
    {path:'details/:id',component:ReviewDetailsComponent},
    {path:'author/:id',component:ReviewAuthorComponent},
    {path:'all/:id',component:ReviewAllComponent}
  ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
