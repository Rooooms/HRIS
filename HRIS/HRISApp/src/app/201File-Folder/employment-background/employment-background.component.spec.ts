import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmploymentBackgroundComponent } from './employment-background.component';

describe('EmploymentBackgroundComponent', () => {
  let component: EmploymentBackgroundComponent;
  let fixture: ComponentFixture<EmploymentBackgroundComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmploymentBackgroundComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EmploymentBackgroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
