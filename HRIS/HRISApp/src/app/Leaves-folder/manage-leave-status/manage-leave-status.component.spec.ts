import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageLeaveStatusComponent } from './manage-leave-status.component';

describe('ManageLeaveStatusComponent', () => {
  let component: ManageLeaveStatusComponent;
  let fixture: ComponentFixture<ManageLeaveStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageLeaveStatusComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManageLeaveStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
