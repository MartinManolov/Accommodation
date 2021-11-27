import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { CreateReservationCommand, ReservationsService } from 'src/app/web-api-client';

@Component({
  selector: 'app-create-reservation',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  reservationForm = this.fb.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    email: ['', [Validators.required]],
    phoneNumber: ['', [Validators.required]]
  })

  offerId: string ;
  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private reservationService: ReservationsService,
              private router: Router) { }

  ngOnInit(): void {
    this.offerId = this.route.snapshot.params['id'];
  }

  create(){
    let reservation:CreateReservationCommand = this.reservationForm.value;
    reservation.offerId = this.offerId;
    this.reservationService.post(reservation).subscribe((id) => {
      this.router.navigate(['/reservations', id]);
    })
  }
}
