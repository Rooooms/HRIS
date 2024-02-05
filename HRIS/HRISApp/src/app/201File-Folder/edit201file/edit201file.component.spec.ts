import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Edit201fileComponent } from './edit201file.component';

describe('Edit201fileComponent', () => {
  let component: Edit201fileComponent;
  let fixture: ComponentFixture<Edit201fileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Edit201fileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(Edit201fileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
