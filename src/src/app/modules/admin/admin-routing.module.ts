import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserFeedbackComponent } from './user-feedback/user-feedback.component';
import { UserComplaintsComponent } from './user-complaints/user-complaints.component';
import { NewPassportListComponent } from './new-passport-list/new-passport-list.component';
import { ReNewPassportListComponent } from './re-new-passport-list/re-new-passport-list.component';

const routes: Routes = [
  {path:'',component:AdminDashboardComponent  },
  {path:'user-list',component:UserListComponent  },
  {path:'user-feedback',component:UserFeedbackComponent  },
  {path:'new-pass-list',component:NewPassportListComponent  },
  {path:'re-newpass-list',component:ReNewPassportListComponent  },
  {path:'user-complaints',component:UserComplaintsComponent  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
