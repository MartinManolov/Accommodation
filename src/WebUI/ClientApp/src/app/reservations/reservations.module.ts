import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ViewComponent } from './view/view.component';
import { ListComponent } from './list/list.component';



@NgModule({
  declarations: [
    CreateComponent,
    ViewComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class ReservationsModule { }
