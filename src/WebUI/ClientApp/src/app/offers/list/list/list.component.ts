import { Component, Input, OnInit } from '@angular/core';
import { OffersListVm } from 'src/app/web-api-client';

@Component({
  selector: 'app-offers-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
 
  @Input() offers: OffersListVm;

  constructor() { }

  ngOnInit(): void {
  }

}
