import { TestBed } from '@angular/core/testing';

import { EmploymentBgService } from './employment-bg.service';

describe('EmploymentBgService', () => {
  let service: EmploymentBgService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmploymentBgService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
