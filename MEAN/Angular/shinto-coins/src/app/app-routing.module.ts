import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {TransactionComponent} from './transaction/transaction.component';
import {BuyComponent} from './buy/buy.component';
import {SellComponent} from './sell/sell.component';
import {MineComponent} from './mine/mine.component';
import {BrowseComponent} from './browse/browse.component';
import { HomeComponent } from './home/home.component';



const routes: Routes = [
  {path:'home',pathMatch:'full',component: HomeComponent},
  {path:'mine', pathMatch:'full', component: MineComponent},
  {path:'buy', pathMatch:'full', component: BuyComponent},
  {path:'sell', pathMatch:'full', component: SellComponent},
  {path:'ledger', pathMatch:'full', component: BrowseComponent},
  {path:'transaction/:id', component: TransactionComponent},
  {path:'',pathMatch:'full', redirectTo:'/home'},
  {path:'**', redirectTo:'/home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
