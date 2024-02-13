import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { BehaviorSubject, Observable, catchError, of, tap, throwError } from 'rxjs';
import { Route } from '@angular/router';
import { Router } from '@angular/router';
import {JwtHelperService} from'@auth0/angular-jwt'
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isAuthenticatedValue: boolean = false;
  baseApiUrl: string = environment.baseApiUrl;

  private role$ = new BehaviorSubject<string>("");

  private userPayload : any;
  constructor(private http: HttpClient, private route: Router) {
    this.userPayload = this.decodeToken();
   }

  login(data: any): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}api/Users/login`, data)
  }


  logout() {
    localStorage.clear();
    this.route.navigate(['login']);

  }

  handleLoginSuccess(token: string) {
    console.log('handle token', token)
    localStorage.setItem('token', token);
    console.log('Token stored:', localStorage.getItem('token'));
  }

  getToken() {
    return localStorage.getItem('token')
  }
  getRefreshToken() {
    return localStorage.getItem('refreshToken')
  }

  private handleError(error: any): Observable<never> {
    // Implement your error handling logic
    console.error('Authentication error', error);
    return throwError(error); // Rethrow the error using throwError
  }

  isAuthenticated(): boolean {
    return this.isAuthenticatedValue;
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getUserInfo(): Observable<any> {
    const token = this.getToken();
    console.log('Token before getUserInfo:', token);

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const options = { headers };

    return this.http.get<any>(`${this.baseApiUrl}api/Users/check-logged`, options).pipe(
      catchError(error => {
        console.error('Error fetching user info:', error);
        return throwError(error);
      })
    );
  }

public getRole(){
  return this.role$.asObservable();
}
public setRole(role:string){
  this.role$.next(role);
}

decodeToken(){
  const jwtHelper = new JwtHelperService();
  const token = this.getToken()!;
  console.log(jwtHelper.decodeToken(token))
  return jwtHelper.decodeToken(token);
}

getRoleFromToken(){
  if(this.userPayload)
  return this.userPayload.role;
}

getUser():Observable<any>{
  return this.http.get(this.baseApiUrl+'api/Users');
}

addNewUser(data:any):Observable<any>{
  return this.http.post(this.baseApiUrl+'api/Users', data)
}

updateUser(id:string, data:any){
  return this.http.put(`http://localhost:5041/api/Users/${id}`, data);
}

}
