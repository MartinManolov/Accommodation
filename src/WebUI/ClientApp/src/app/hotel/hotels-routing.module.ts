import { NgModule } from '@angular/core';

import { HotelsListComponent } from './hotels-list/hotels-list.component';
import { RouterModule, Routes } from '@angular/router';
import { ViewComponent } from './view/view.component';

const routes: Routes = [
  { path: '', component: HotelsListComponent },
  {path: ':id', component: ViewComponent}
  
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class HotelsRoutingModule { } 
