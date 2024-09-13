import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPassportListComponent } from './new-passport-list.component';

describe('NewPassportListComponent', () => {
  let component: NewPassportListComponent;
  let fixture: ComponentFixture<NewPassportListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NewPassportListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewPassportListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
