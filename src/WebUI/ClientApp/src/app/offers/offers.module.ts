import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewComponent } from './view/view.component';
import { RouterModule } from '@angular/router';
import { RoomsModule } from '../rooms/rooms.module';



@NgModule({
  declarations: [
    ViewComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    RoomsModule
  ],
  exports: [
    ViewComponent
  ]
})
export class OffersModule { }
