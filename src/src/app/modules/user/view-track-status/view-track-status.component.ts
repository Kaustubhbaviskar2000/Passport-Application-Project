import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-view-track-status',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,RouterLink],
  templateUrl: './view-track-status.component.html',
  styleUrl: './view-track-status.component.css'
})
export class ViewTrackStatusComponent {

  trackForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.trackForm = this.fb.group({
      passportNumber: [{ value: '', disabled: true }],
      givenName: [{ value: '', disabled: true }],
      applicationType: [{ value: 'Normal', disabled: true }],
      receivedDate: [{ value: '2024-06-10', disabled: true }],
      status: [{ value: 'Passport has been printed and applicant will receive an SMS/email once the passport is dispatched.', disabled: true }]
    });
  }
}
