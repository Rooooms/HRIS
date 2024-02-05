import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPaymastComponent } from './edit-paymast.component';

describe('EditPaymastComponent', () => {
  let component: EditPaymastComponent;
  let fixture: ComponentFixture<EditPaymastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditPaymastComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditPaymastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
