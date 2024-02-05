import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Add201fileComponent } from './add201file.component';

describe('Add201fileComponent', () => {
  let component: Add201fileComponent;
  let fixture: ComponentFixture<Add201fileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Add201fileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(Add201fileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
