import { Routes } from '@angular/router';
import { PagenotfoundComponent } from './core/components/pagenotfound/pagenotfound.component';
import { appGuardGuard } from './Guards/app-guard.guard';

export const routes: Routes = [
    {
        path:'',
        loadChildren:() => import('./modules/public/public.module').then(x => x.PublicModule)
    },
    {
        path:'user',canActivate:[appGuardGuard],
        loadChildren:() => import('./modules/user/user.module').then(m => m.UserModule)
    },
    {
        path:'admin',canActivate:[appGuardGuard],
        loadChildren:() => import('./modules/admin/admin.module').then(m => m.AdminModule)
    }
    ,
    {path:"**",component:PagenotfoundComponent,pathMatch:'full'}
];
