import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBenefitComponent } from './view-benefit.component';

describe('ViewBenefitComponent', () => {
  let component: ViewBenefitComponent;
  let fixture: ComponentFixture<ViewBenefitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewBenefitComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewBenefitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
