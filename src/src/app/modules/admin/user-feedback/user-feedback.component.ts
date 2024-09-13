import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { IFeedbackForm } from '../../../core/interfaces/IFeedbackForm';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-feedback',
  standalone: true,
  imports: [CommonModule],
  providers:[UserService],
  templateUrl: './user-feedback.component.html',
  styleUrl: './user-feedback.component.css'
})
export class UserFeedbackComponent implements OnInit{
  
  feedbackList:IFeedbackForm[]=[];
  constructor(private userService:UserService){}

  ngOnInit(): void {
    this.InItComponent();
  }

  InItComponent = () =>{
    this.userService.GetUserFeedback().subscribe(
      (data)=>{
        this.feedbackList = data
      }
    )
  }
  HandleEdit = () =>{

  }
  HandleDelete = () =>{
    
  }
}
