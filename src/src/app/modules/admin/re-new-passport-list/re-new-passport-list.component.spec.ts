import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReNewPassportListComponent } from './re-new-passport-list.component';

describe('ReNewPassportListComponent', () => {
  let component: ReNewPassportListComponent;
  let fixture: ComponentFixture<ReNewPassportListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReNewPassportListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReNewPassportListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
