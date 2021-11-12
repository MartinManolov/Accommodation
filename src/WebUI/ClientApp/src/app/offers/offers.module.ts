import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewComponent } from './view/view.component';
import { RouterModule } from '@angular/router';
import { RoomsModule } from '../rooms/rooms.module';
import { ListComponent } from './list/list/list.component';



@NgModule({
  declarations: [
    ViewComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    RoomsModule
  ],
  exports: [
    ViewComponent,
    ListComponent
  ]
})
export class OffersModule { }
