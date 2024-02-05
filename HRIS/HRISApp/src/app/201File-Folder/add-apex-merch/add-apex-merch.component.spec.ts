import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddApexMerchComponent } from './add-apex-merch.component';

describe('AddApexMerchComponent', () => {
  let component: AddApexMerchComponent;
  let fixture: ComponentFixture<AddApexMerchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddApexMerchComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddApexMerchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
