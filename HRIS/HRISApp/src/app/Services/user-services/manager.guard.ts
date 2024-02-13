// manager.guard.ts
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { UserService } from './user.service';
import { Observable, map } from 'rxjs';
import { CoreService } from '../core-service/core.service';


@Injectable({
  providedIn: 'root'
})
export class ManagerGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router, private coreService :CoreService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.userService.getUserInfo().pipe(
      map(user => {
        if (user && user.userType === 'Manager'||user && user.userType === 'Admin') {
          return true; // Allow access for managers
        } else {
          this.coreService.openSnackBar('Access Denied')
          this.router.navigate(['Dashboard']); // Redirect to dashboard if not a manager
          return false;
        }
      })
    );
  }
}
