import { TestBed } from '@angular/core/testing';

import { PaymastService } from './paymast.service';

describe('PaymastService', () => {
  let service: PaymastService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PaymastService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
