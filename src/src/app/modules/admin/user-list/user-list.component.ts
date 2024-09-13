import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { IUserRegistration } from '../../../core/interfaces/IUserRegistration';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { FormsModule } from '@angular/forms';
import { map } from 'rxjs';
import { Role } from '../../../core/constants/Role';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [CommonModule,FormsModule],
  providers:[UserService],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit{

  userList:IUserRegistration[]=[];
  isEditModalVisible: boolean = false;
  selectedUser: IUserRegistration | null = null;

  constructor(private userService:UserService){

  }
  ngOnInit(): void {
    this.InItComponent();
  }

  InItComponent = () =>{
    return this.userService.GetAllUser().pipe(
      map(res => res.filter(x => x.role !== Role.Admin))
    ).subscribe(
      (data)=>{
        this.userList = data;
      }
    )
  }
  HandleEdit = (id: string) => {
    this.userService.getUserById(id).subscribe((user) => {
      this.selectedUser = user;
      this.isEditModalVisible = true;
    });
  }
  HandleSave = () => {
    if (this.selectedUser) {
      this.userService.editUser(this.selectedUser.userId, this.selectedUser).subscribe(
        (updatedUser) => {
          this.ShowAlert(updatedUser, 'User updated successfully', 'success');
          this.isEditModalVisible = false;
          this.InItComponent();
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
          this.userService.deleteUser(id).subscribe(
            (data:IUserRegistration)=>{
              this.ShowAlert(data, 'User Deleted successfully', 'success');
            }
          )
        }
      });
    }
  }
  ShowAlert = (data: IUserRegistration | null, message: string, icon: 'success' | 'error') => {
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
