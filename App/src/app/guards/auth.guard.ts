import { CanActivateFn, Router } from '@angular/router';
import {inject} from '@angular/core';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const loginService = inject(AuthService);
  const router = inject(Router);
  if (loginService.isLoggedIn()) {
    return true;
  } else {
    router.navigate(['/login']);
    return false;
  }
  //return loginService.isLoggedIn();
};


