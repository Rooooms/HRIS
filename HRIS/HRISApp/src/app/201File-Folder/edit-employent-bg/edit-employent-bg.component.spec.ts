import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmployentBgComponent } from './edit-employent-bg.component';

describe('EditEmployentBgComponent', () => {
  let component: EditEmployentBgComponent;
  let fixture: ComponentFixture<EditEmployentBgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditEmployentBgComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditEmployentBgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
