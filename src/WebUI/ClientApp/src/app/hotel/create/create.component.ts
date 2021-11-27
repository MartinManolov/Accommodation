import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HotelsService } from 'src/app/web-api-client';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  facilities: FormArray;

  hotelForm = this.fb.group({
    name: ['',[Validators.minLength(3), Validators.required, Validators.maxLength(25)]],
    description: ['',[Validators.maxLength(200)]],
    facilities: this.fb.array([this.createFacility()]),
    email: ['',[Validators.required, Validators.email]],
    phoneNumber: ['', [Validators.required]],
    country: ['', [Validators.required]],
    city: ['', [Validators.required]],
    locationLatitude: ['',[Validators.min(-90), Validators.max(90)]],
    locationLongitude: ['',[Validators.min(-180), Validators.max(180)]]
  })

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private hotelService: HotelsService,
              private router: Router ) {}

  ngOnInit(): void {
  }

  createFacility(): FormGroup {
    return this.fb.group({
      name: '',
    });
  }

  addFacility(): void {
    this.facilities = this.hotelForm.get('facilities') as FormArray;
    this.facilities.push(this.createFacility());
  }

  removeFacility(index): void {
    this.facilities = this.hotelForm.get('facilities') as FormArray;
    this.facilities.removeAt(index);
  }

  create(){

  }
}
