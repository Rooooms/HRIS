
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { UserService } from '../user.service';

@Injectable()

export class TokenInterceptor implements HttpInterceptor{

  constructor(private userService: UserService, private router: Router){}

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.userService.getToken();

    console.log('Interceptor Token', token)

    if(token){
      req = req.clone({
        setHeaders: {Authorization:`Bearer ${token}`}  // "Bearer "+myToken
    })
    console.log('Set Header', req)
  }

  return next.handle(req).pipe(
    catchError((err:any)=>{
      if(err instanceof HttpErrorResponse){
        if(err.status === 401){
          //this.toast.warning({detail:"Warning", summary:"Token is expired, Please Login again"});
          this.router.navigate(['login'])
          //handle
          // return this.handleUnAuthorizedError(req,next);
        }
      }
      return throwError(()=> err)
    })
  );
}

}