import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditbookComponent } from './add-editbook.component';

describe('AddEditbookComponent', () => {
  let component: AddEditbookComponent;
  let fixture: ComponentFixture<AddEditbookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditbookComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddEditbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
