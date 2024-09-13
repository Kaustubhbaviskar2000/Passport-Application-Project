import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTrackStatusComponent } from './view-track-status.component';

describe('ViewTrackStatusComponent', () => {
  let component: ViewTrackStatusComponent;
  let fixture: ComponentFixture<ViewTrackStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ViewTrackStatusComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewTrackStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
