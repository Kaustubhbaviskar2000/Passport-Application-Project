import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrackStatusComponent } from './track-status/track-status.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { ViewTrackStatusComponent } from './view-track-status/view-track-status.component';
import { PaymentComponent } from './payment/payment.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { NewPassportApplyComponent } from './new-passport-apply/new-passport-apply.component';
import { RenewalPassportApplyComponent } from './renewal-passport-apply/renewal-passport-apply.component';

const routes: Routes = [
  {path:'',component:UserDashboardComponent},
  {path:'back',component:UserDashboardComponent},
  {path:'track-status',component:TrackStatusComponent},
  {path:'payment',component:PaymentComponent},
  {path:'feedback',component:FeedbackComponent},
  {path:'newpassport',component:NewPassportApplyComponent},
  {path:'renewalpassport',component:RenewalPassportApplyComponent},
  {path:'view-status',component:ViewTrackStatusComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
