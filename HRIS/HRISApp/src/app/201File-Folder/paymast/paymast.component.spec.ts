import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymastComponent } from './paymast.component';

describe('PaymastComponent', () => {
  let component: PaymastComponent;
  let fixture: ComponentFixture<PaymastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PaymastComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PaymastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
