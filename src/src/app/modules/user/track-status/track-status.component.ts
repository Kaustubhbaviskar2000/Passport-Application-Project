import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { PassportApplyService } from '../../../core/services/passport-apply.service';
import { INewPassportForm } from '../../../core/interfaces/INewPassportForm';
import { IReNewForm } from '../../../core/interfaces/IReNewForm';
import Swal from 'sweetalert2';
import { error } from 'console';
import { ITrackPassportData } from '../../../core/interfaces/ITrackPassportData';
import { UserService } from '../../../core/services/user.service';
import { ITrackPassportDetails } from '../../../core/interfaces/ITrackPassportDetails';

@Component({
  selector: 'app-track-status',
  standalone: true,
  imports: [RouterLink,ReactiveFormsModule,CommonModule],
  providers:[UserService],
  templateUrl: './track-status.component.html',
  styleUrl: './track-status.component.css'
})
export class TrackStatusComponent implements OnInit {

  trackForm:FormGroup = <FormGroup>{};
  isUserPassportExist:Boolean = false;
  passportData:ITrackPassportDetails = <ITrackPassportDetails>{};
  
  constructor(private fb: FormBuilder,private router:Router,private service:UserService) {
    
  }

  ngOnInit(): void {
    this.trackForm = this.InItForm();
  }
  InItForm = ():FormGroup =>{
    return this.trackForm = this.fb.group({
      applicationType: ['', Validators.required],
      passportNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      dob: ['', Validators.required]
    });
  }
  handleSubmit(): void {
    if (this.trackForm.valid) {
      this.TrackPassportStatus();
    } else {
      // Mark all controls as touched to trigger validation messages
      this.trackForm.markAllAsTouched();
    }
  }

  TrackPassportStatus = () =>{
      this.service.TrackPassportStatus(this.trackForm.value).subscribe({
        next:(success:ITrackPassportDetails)=>{
            this.passportData = success
            this.ShowAlert(true);
        },  
        error:(error) =>{
          this.ShowAlert(false);
        }
      })
  }

  ShowAlert = (isPassport:Boolean) => {
    if(isPassport){
      Swal.fire({
        title: "Excellent",
        text: "Track your status",
        icon: "success"
      }).then((res)=>{
        if(res.isConfirmed){
          this.isUserPassportExist = true;
        }
      });
    }else{
      Swal.fire({
        title: "Passport does not exist",
        text: "Please enter correct details",
        icon: "error"
      });
    }
  }
}
