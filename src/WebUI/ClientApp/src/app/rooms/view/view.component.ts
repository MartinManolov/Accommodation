import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { RoomDto, RoomsService } from 'src/app/web-api-client';

@Component({
  selector: 'app-room-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewComponent implements OnInit {

  room$: Observable<RoomDto>;
  @Input() id: string
  constructor(private service: RoomsService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    
    if(this.router.url.includes('rooms')){
      let roomId = this.route.snapshot.params['id'];
      this.room$ = this.service.get(roomId);
    }
    else{
    this.room$ = this.service.get(this.id);
  }
  }


}
