import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../user.service';
import { NgToastService } from 'ng-angular-popup';
import { CoreService } from '../../core-service/core.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardGuard implements CanActivate {

  constructor(
    private userService: UserService,
    private router: Router,
    private core: CoreService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    console.log('AuthGuard is being executed.');

    if (this.userService.isLoggedIn()) {
      return true;  // User is logged in, allow access to the route
    } else {
      this.core.openSnackBar('Please Login First')
      this.router.navigate(['login']);
      return false;
    }
  }
}
