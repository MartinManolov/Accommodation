import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { HomeComponent } from './shared/home/home.component';
import { TokenComponent } from './shared/token/token.component';

export const routes: Routes = [

  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] },
  {
    path: 'hotels',
    loadChildren: () => import('./hotel/hotels-routing.module').then(m => m.HotelsRoutingModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
