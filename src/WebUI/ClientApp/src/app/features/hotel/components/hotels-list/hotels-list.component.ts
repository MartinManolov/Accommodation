import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HotelInListDto, HotelsListVm, HotelsService } from 'src/app/web-api-client';

@Component({
  selector: 'app-hotels-list',
  templateUrl: './hotels-list.component.html',
  styleUrls: ['./hotels-list.component.scss']
})
export class HotelsListComponent implements OnInit {

  hotels: Array<HotelInListDto>;
  constructor(private service: HotelsService) { }

  ngOnInit(): void {
    this.service.getAll().subscribe((data) => {
      this.hotels = data['hotels'];
    });
  }

}
