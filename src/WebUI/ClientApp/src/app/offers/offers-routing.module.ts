import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../shared/home/home.component';
import { ViewComponent } from './view/view.component';

const routes: Routes = [
  {path: '', component: ViewComponent, pathMatch: 'full'},
  {path: ':id', component: ViewComponent}
  ];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports : [RouterModule]
})
export class OffersRoutingModule { }
