import { Component, OnInit } from '@angular/core';
import { MedicineServiceService } from '../services/medicineservice.service';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public gridData;
  displayedColumns: string[] = ['fullName', 'brand', 'quantity', 'price', 'expiryDate'];
  dataSource = new MatTableDataSource();
  originalData;
  public _MS_PER_DAY = 1000 * 60 * 60 * 24;
  constructor(private medicineServiceService: MedicineServiceService, private router: Router) {

  }

  ngOnInit() {
    this.getMedicines();
  }

  public getMedicines() {
    this.medicineServiceService.getMedicines().subscribe((response) =>
    {
      this.gridData = response

      this.originalData = response;
    },
    (error) => {

    })
  }

  public addMedicine() {
    this.router.navigate(['/medicine']);
  }

  public checkExpiryDue(expiryDate) { 
    var expiry = new Date(expiryDate);
    var currentDate = new Date();  
    const dayDiff = this.dateDiffInDays(currentDate, expiry)

    return dayDiff;
  }

  public dateDiffInDays(a, b) {
    const utc1 = Date.UTC(a.getFullYear(), a.getMonth(), a.getDate());
    const utc2 = Date.UTC(b.getFullYear(), b.getMonth(), b.getDate());

    return Math.floor((utc2 - utc1) / this._MS_PER_DAY);
  }

  public filterHandler(filterValue) {
    let filter = filterValue.target.value.toLowerCase();
    let filterdata = this.originalData.filter(r => r.fullName.toLowerCase().includes(filter))
    this.gridData = filterdata; 
  }
}
