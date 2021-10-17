import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ViewComponent } from './view/view.component';



@NgModule({
  declarations: [
    CreateComponent,
    ViewComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class ReservationsModule { }
