import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Observable } from 'rxjs';
import { HotelsService, HotelVm } from 'src/app/web-api-client';

@Component({
  selector: 'app-hotel-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {
  hotel$ : Observable<HotelVm>
  constructor(private service : HotelsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id'];
    this.hotel$ = this.service.get(id)
    
  }

}
