import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../../core/services/user.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
import { FeedbackStatus } from '../../../core/constants/FeedbackStatus';
import { Feedback } from '../../../core/constants/Feedback';
import { ILoggedInUser } from '../../../core/interfaces/ILoggedInUser';

@Component({
  selector: 'app-feedback',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './feedback.component.html',
  styleUrl: './feedback.component.css'
})
export class FeedbackComponent implements OnInit{

  feedbackForm:FormGroup = <FormGroup>{};
  LoggedInUserData:ILoggedInUser = {} as ILoggedInUser;
  constructor(private fb: FormBuilder,private service:UserService,private router:Router) {
    
  }

  ngOnInit(): void {
    if(typeof window !== 'undefined' && window.localStorage){
      const data = localStorage.getItem('loggedUser');
      if(data){
        this.LoggedInUserData = JSON.parse(data);
      }          
    }
    this.feedbackForm = this.InItForm();
  }

  InItForm = () =>{
    return this.feedbackForm = this.fb.group({
      userName: ['', [Validators.required,Validators.minLength(5), Validators.maxLength(45)]],
      emailAddress: ['', [Validators.required, Validators.email, Validators.maxLength(35)]],
      feedbackType: ['', Validators.required],
      feedbackDescription: ['', Validators.required],
      feedbackStatus:[FeedbackStatus.Pending],
      userId:[this.LoggedInUserData.userId]
    });
  }

  SaveFeedback = () =>{
    console.log(this.feedbackForm.value);
    this.service.SaveFeedback(this.feedbackForm.value).subscribe((data)=>{
      Swal.fire({
        title: "Feedback Sent",
        text: `Your ${this.feedbackForm.get('feedbackType')?.value} is sent`,
        icon: "success"
      }).then((res)=>{
        if(res.isConfirmed){
          this.router.navigate(['user']);
        }
      });
    });
  }

  handleSubmit(): void {
    if (this.feedbackForm.valid) {
        this.SaveFeedback();
      // Handle form submission logic here
    } else {
      // Mark all controls as touched to trigger validation messages
      this.feedbackForm.markAllAsTouched();
    }
  }
}
