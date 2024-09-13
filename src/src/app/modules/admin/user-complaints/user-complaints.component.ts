import { Component } from '@angular/core';
import { IFeedbackForm } from '../../../core/interfaces/IFeedbackForm';
import { UserService } from '../../../core/services/user.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FeedbackStatus } from '../../../core/constants/FeedbackStatus';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-complaints',
  standalone: true,
  imports: [CommonModule,FormsModule],
  providers:[UserService],
  templateUrl: './user-complaints.component.html',
  styleUrl: './user-complaints.component.css'
})
export class UserComplaintsComponent {
  complaintList:IFeedbackForm[]=[];
  selectedComplaint: IFeedbackForm | null = null;
  isEditModalVisible: boolean = false;
  feedbackStatus:string[] = [];

  constructor(private userService:UserService){}

  ngOnInit(): void {
    this.InItComponent();
    this.feedbackStatus = Object.values(FeedbackStatus);
  }

  InItComponent = () =>{
    this.userService.GetUserComplaints().subscribe(
      (data)=>{
        this.complaintList = data
      }
    )
  }
  HandleEdit = (id: string) => {
    alert(id);
    this.userService.getComplentById(id).subscribe((user) => {
      this.selectedComplaint = user;
      this.isEditModalVisible = true;
    });
  }
  HandleSave = () => {
    if (this.selectedComplaint) {
      this.userService.updateComplaintStatus(this.selectedComplaint.feedbackId, this.selectedComplaint).subscribe(
        {
          next:(success)=>{
            this.ShowAlert(success, 'User updated successfully', 'success');
            this.isEditModalVisible = false;
            this.InItComponent();
          },
          error:()=>{

          }  
        }
      );
    }
  }
  HandleDelete = (id:string) =>{
    if(id !== null){
      Swal.fire({
        title: "Are you sure",
        text: "You want to delete user",
        icon: "info",
        showCancelButton: true,
        confirmButtonText: "Delete",
      }).then((res)=>{
        if(res.isConfirmed){
          this.userService.deleteComplaintById(id).subscribe(
            (data:IFeedbackForm)=>{
              this.ShowAlert(data, 'User Deleted successfully', 'success');
            }
          )
        }
      });
    }
  }
  ShowAlert = (data: IFeedbackForm | null, message: string, icon: 'success' | 'error') => {
    Swal.fire({
      title: icon === 'success' ? 'Success' : 'Error',
      text: message,
      icon: icon
    }).then(() => {
      if (icon === 'success') {
        this.InItComponent();
      }
    });
  }
}
