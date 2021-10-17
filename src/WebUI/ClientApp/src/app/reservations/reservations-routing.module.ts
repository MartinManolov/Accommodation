import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './create/create.component';
import { ViewComponent } from './view/view.component';
import { ListComponent } from './list/list.component';



const routes: Routes = [
  {path: '' , component: ListComponent, pathMatch: 'full'},
  {path: 'create/:id', component: CreateComponent},
  {path: ':id', component: ViewComponent}
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ReservationsRoutingModule { }
