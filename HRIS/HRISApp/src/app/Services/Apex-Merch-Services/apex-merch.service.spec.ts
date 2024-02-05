import { TestBed } from '@angular/core/testing';

import { ApexMerchService } from './apex-merch.service';

describe('ApexMerchService', () => {
  let service: ApexMerchService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApexMerchService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
