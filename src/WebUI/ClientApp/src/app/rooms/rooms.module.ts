import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewComponent } from './view/view.component';
import { CreateComponent } from './create/create.component';



@NgModule({
  declarations: [
    ViewComponent,
    CreateComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ViewComponent
  ]
})
export class RoomsModule { }
