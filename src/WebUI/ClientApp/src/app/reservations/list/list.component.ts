import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ReservationsService, UserReservationsListVm } from 'src/app/web-api-client';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  
  reservations$: Observable<UserReservationsListVm>

  constructor(private reservationService: ReservationsService) { }

  ngOnInit(): void {
      this.reservations$ = this.reservationService.getAllByUser();
  }

}
