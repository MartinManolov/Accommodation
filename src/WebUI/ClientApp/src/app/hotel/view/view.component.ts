import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HotelsService, HotelVm } from 'src/app/web-api-client';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {
  hotel : HotelVm
  constructor(private service : HotelsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params['id'])
    
  }

}
