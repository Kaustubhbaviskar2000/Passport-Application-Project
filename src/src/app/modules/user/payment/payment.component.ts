import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { PassportApplyService } from '../../../core/services/passport-apply.service';
import { INewPassportForm } from '../../../core/interfaces/INewPassportForm';
import { IReNewForm } from '../../../core/interfaces/IReNewForm';
import { Router } from '@angular/router';
import { UserService } from '../../../core/services/user.service';
import { ITrackPassportDetails } from '../../../core/interfaces/ITrackPassportDetails';

@Component({
  selector: 'app-payment',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  providers:[UserService],
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.css'
})
export class PaymentComponent implements OnInit {

  paymentForm:FormGroup = <FormGroup>{};
  trackForm:FormGroup = <FormGroup>{};
  passportData:ITrackPassportDetails = <ITrackPassportDetails>{};
  isUserPassportExist:Boolean = false;
  router = inject(Router);
  constructor(private fb: FormBuilder,private service:UserService) {
    
  }

  ngOnInit(): void {
    this.trackForm = this.InItTrackForm();
    this.paymentForm = this.InItPaymentForm();
  }

  InItTrackForm = ():FormGroup =>{
    return this.trackForm = this.fb.group({
      applicationType: ['', Validators.required],
      passportNumber: ['', [Validators.required, Validators.pattern('^[0-9]{10}$')]],
      dob: ['', Validators.required]
    });
  }

  InItPaymentForm = ():FormGroup =>{
    return this.paymentForm = this.fb.group({
      paymentType: ['', Validators.required],
      name: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]],
      cardNumber: ['', [Validators.required]],
      expiryDate: ['', Validators.required],
      cvv: ['', [Validators.required, Validators.pattern('^[0-9]{3}$')]],
      amount: [{ value: 350, disabled: true }]
    });
  }

  ProceedToPay(): void {
    if (this.trackForm.valid) {
      this.TrackPassportStatus();
    } else {
      // Mark all controls as touched to trigger validation messages
      this.trackForm.markAllAsTouched();
    }
  }
  MakePayment = () =>{
    if(this.paymentForm.valid){
      this.service.MakePassportPayment(this.trackForm.value).subscribe({
        next:() =>{
          Swal.fire({
            title: "Payment Successful",
            text: "Excellent",
            icon: "success"
          }).then((res)=>{
            if(res.isConfirmed){
              this.router.navigate(['user']);
            }
          });
        },
        error:(error) =>{

        }
      })
      
    }else{
      this.paymentForm.markAllAsTouched();
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
