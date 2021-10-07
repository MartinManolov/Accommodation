import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HotelsListComponent } from './components/hotels-list/hotels-list.component';



@NgModule({
  declarations: [
    HotelsListComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [HotelsListComponent]
})
export class HotelModule { }
