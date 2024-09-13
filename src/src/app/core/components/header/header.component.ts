import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { Role } from '../../constants/Role';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{

  userService = inject(UserService);
  isLoggedIn:string = '';

  constructor(private router:Router){}
  ngOnInit(): void {
    this.router.events.subscribe(
      (data:any)=>{
        if(data.url){
          if(typeof window !== 'undefined' && window.localStorage){
              if(localStorage.getItem('loggedUser') && (data.url.includes('user') || data.url.includes('admin'))){
                this.isLoggedIn = 'user';
              }else{
                this.isLoggedIn = 'default'; 
              }
            }
          }
        }
    )
  }

  HandleLogout = () =>{
    if(typeof window !== 'undefined' && window.localStorage){
      localStorage.removeItem('loggedUser');
    }
  }

}
