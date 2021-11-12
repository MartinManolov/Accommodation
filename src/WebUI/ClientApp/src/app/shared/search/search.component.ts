import { Component, EventEmitter, Output } from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms'
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { OffersListVm, OffersService } from 'src/app/web-api-client';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent{
  searchForm = new FormGroup({
    parameter: new FormControl(),
    checkIn: new FormControl(),
    checkOut: new FormControl(),
    people: new FormControl()
  })
  offers$: Observable<OffersListVm>
  offers: any;

  constructor(private fb: FormBuilder, private offersService: OffersService, private router: Router) { }

  Search(){
   this.offersService.getBySearch(this.searchForm.controls['parameter'].value,
                                    this.searchForm.controls['checkIn'].value ,
                                    this.searchForm.controls['checkOut'].value,
                                    this.searchForm.controls['people'].value)
                                    .subscribe( offers => {
                                      this.offers = offers;
                                    })
               
  }
}
