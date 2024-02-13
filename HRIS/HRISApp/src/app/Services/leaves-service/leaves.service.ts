import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LeavesService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }

  getLeaves(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/Leave/my-leaves');
  }

  addLeaves(data :  any): Observable <any> {
    return this.http.post <any> (this.baseApiUrl + 'api/Leave', data )
  }

  // Inside your Angular service where the HTTP request is made
updateLeaves(id: string, data: any): Observable<any> {
  return this.http.put(`http://localhost:5041/api/Leave/${id}`, data)
    .pipe(
      tap(response => console.log('API Response:', response)),
      catchError(error => {
        console.error('API Error:', error);
        throw error;
      })
    );
}

getLeaveByDepartment(department:any): Observable<any>{
  return this.http.get(`http://localhost:5041/api/Leave/department?department=${department}`)
}

}
