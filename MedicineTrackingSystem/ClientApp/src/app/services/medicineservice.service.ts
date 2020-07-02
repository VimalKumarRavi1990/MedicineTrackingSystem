import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MedicineServiceService {

  constructor(private http: HttpClient) { }

  getMedicines(): Observable<any> {
    return this.http.get('http://localhost:7410/api/medicaltracking/getmedicines');
  }

  addMedicine(medicineModel): Observable<any> {
    return this.http.post('http://localhost:7410/api/medicaltracking/addmedicine', medicineModel);
  }

  editMedicine(medicineModel): Observable<any> {
    return this.http.post('http://localhost:7410/api/medicaltracking/updatemedicine', medicineModel);
  }
}
