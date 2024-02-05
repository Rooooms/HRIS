import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable, catchError, of, tap, throwError } from 'rxjs';
import { Route } from '@angular/router';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private isAuthenticatedValue: boolean = false;
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient, private route: Router) { }

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





}
