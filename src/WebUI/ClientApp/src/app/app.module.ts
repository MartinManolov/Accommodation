import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';

import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { HotelModule } from './hotel/hotels.module';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { HomeComponent } from './shared/home/home.component';
import { TokenComponent } from './shared/token/token.component';
import { RoomsModule } from './rooms/rooms.module';
import { OffersModule } from './offers/offers.module';
import { ReservationsModule } from './reservations/reservations.module';
import { SearchComponent } from './shared/search/search.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TokenComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    ReactiveFormsModule,
    HotelModule,
    RoomsModule,
    OffersModule,
    ReservationsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
