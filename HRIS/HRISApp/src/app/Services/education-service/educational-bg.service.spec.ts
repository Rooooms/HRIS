import { TestBed } from '@angular/core/testing';

import { EducationalBgService } from './educational-bg.service';

describe('EducationalBgService', () => {
  let service: EducationalBgService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EducationalBgService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
