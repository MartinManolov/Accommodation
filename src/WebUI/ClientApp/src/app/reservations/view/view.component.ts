import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ReservationsService, UserReservationDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-reservation-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {

  reservation$: Observable<UserReservationDto>

  constructor(private reservationService: ReservationsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let reservationId = this.route.snapshot.params['id'];
    this.reservation$ = this.reservationService.get(reservationId);
  }

}
