import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEducationalBgComponent } from './edit-educational-bg.component';

describe('EditEducationalBgComponent', () => {
  let component: EditEducationalBgComponent;
  let fixture: ComponentFixture<EditEducationalBgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditEducationalBgComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditEducationalBgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
