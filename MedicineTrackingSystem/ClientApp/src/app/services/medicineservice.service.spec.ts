import { TestBed } from '@angular/core/testing';

import { MedicineserviceService } from './medicineservice.service';

describe('MedicineserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MedicineserviceService = TestBed.get(MedicineserviceService);
    expect(service).toBeTruthy();
  });
});
