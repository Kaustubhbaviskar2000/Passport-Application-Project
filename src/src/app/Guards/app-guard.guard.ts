import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const appGuardGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  let isLoggedIn= false;
  if(typeof window !== 'undefined' && window.localStorage){
    if(localStorage.getItem('loggedUser')){
      isLoggedIn = true;
    }else{
      router.navigate(['login']);
      isLoggedIn = false;
    }
  }
  return isLoggedIn;
};
