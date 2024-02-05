import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BankRemitDetailsComponent } from './bank-remit-details.component';

describe('BankRemitDetailsComponent', () => {
  let component: BankRemitDetailsComponent;
  let fixture: ComponentFixture<BankRemitDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BankRemitDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BankRemitDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
