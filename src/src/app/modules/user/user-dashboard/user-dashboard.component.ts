import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ILoggedInUser } from '../../../core/interfaces/ILoggedInUser';

@Component({
  selector: 'app-user-dashboard',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './user-dashboard.component.html',
  styleUrl: './user-dashboard.component.css'
})
export class UserDashboardComponent implements OnInit{
  LoggedInUserData:ILoggedInUser = {} as ILoggedInUser;

    ngOnInit(): void {
      if(typeof window !== 'undefined' && window.localStorage){
        const data = localStorage.getItem('loggedUser');
        if(data){
          this.LoggedInUserData = JSON.parse(data);
        }          
      }
    }
}
