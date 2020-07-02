import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MedicineServiceService } from '../services/medicineservice.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'medicine-component',
  templateUrl: './medicine.component.html'
})
export class MedicineComponent implements OnInit {
  public formGroup: FormGroup;
  constructor(private medicineServiceService: MedicineServiceService, private router: Router) {

  }

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.formGroup = new FormGroup({
      id: new FormControl(0),
      fullName : new FormControl(''),
      brand : new FormControl(''),
      price : new FormControl(0),
      quantity : new FormControl(0),
      expiryDate: new FormControl(''),
      notes: new FormControl('')
    })
  }

  public goBack() {
    this.router.navigate(['']);
  }

  public addMedicine() {
    var medicine = this.formGroup.value;
    medicine.expiryDate = this.getFormattedDate(medicine.expiryDate);
    medicine.quantity = parseInt(medicine.quantity);
    medicine.price = parseInt(medicine.price); 
    this.medicineServiceService.addMedicine(this.formGroup.value).subscribe((response) => {
      this.router.navigate(['']);
    },
    (error) => {

    })
  }

  public getFormattedDate(date) {
  let year = date.getFullYear();
  let month = (1 + date.getMonth()).toString().padStart(2, '0');
  let day = date.getDate().toString().padStart(2, '0');

  return month + '/' + day + '/' + year;
}
}
