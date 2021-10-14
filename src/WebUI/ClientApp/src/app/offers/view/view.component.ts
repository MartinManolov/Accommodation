import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { OfferDto, OffersService } from 'src/app/web-api-client';

@Component({
  selector: 'app-offer-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {

  offer$: Observable<OfferDto>;
  constructor(private offersService: OffersService, private route: ActivatedRoute) {
    let id = this.route.snapshot.params['id']
    this.offer$ = offersService.get(id);
   }

  ngOnInit(): void {

  }

}
