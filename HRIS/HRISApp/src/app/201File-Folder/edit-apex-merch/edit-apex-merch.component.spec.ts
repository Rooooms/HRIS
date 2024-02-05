import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditApexMerchComponent } from './edit-apex-merch.component';

describe('EditApexMerchComponent', () => {
  let component: EditApexMerchComponent;
  let fixture: ComponentFixture<EditApexMerchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditApexMerchComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditApexMerchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
