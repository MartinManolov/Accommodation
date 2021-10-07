import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HotelsListComponent } from './hotels-list/hotels-list.component';
import { ViewComponent } from './view/view.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HotelsListComponent,
    ViewComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [HotelsListComponent]
})
export class HotelModule { }
