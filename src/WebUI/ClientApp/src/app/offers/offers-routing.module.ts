import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from '../reservations/list/list.component';
import { HomeComponent } from '../shared/home/home.component';
import { ViewComponent } from './view/view.component';

const routes: Routes = [
  {path: ':id', component: ViewComponent},
  { path: 'list', component: ListComponent}
  ];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports : [RouterModule]
})
export class OffersRoutingModule { }
