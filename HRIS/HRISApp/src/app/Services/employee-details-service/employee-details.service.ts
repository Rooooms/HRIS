import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {


  

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }


 
   
  getEmployeeDetails(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/EmployeeDetails');
  }

  getEmployeeById(id : string): Observable <any> {
    return this.http.get(`http://localhost:5041/api/EmployeeDetails/${id}`);
  }

  addEmployeeDetails(data :  any): Observable <any> {
    
    return this.http.post <any> (this.baseApiUrl + 'api/EmployeeDetails', data )
  }

  updateEmployeeDetails(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
    console.log('Update data:', data);
    return this.http.put(`http://localhost:5041/api/EmployeeDetails/${id}`, data);
  }

  deleteEmployeeDetails(id : string) : Observable<any>{
    return this.http.delete(`http://localhost:5041/api/EmployeeDetails/${id}`)
  }
  
  //this is for book example

  getBooks(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/Book');
  }

  addBook(data :  any): Observable <any> {
    
    return this.http.post <any> (this.baseApiUrl + 'api/Book', data )
  }

  updateBooks(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
 
  
    return this.http.put(`http://localhost:5041/api/Book/${id}`, data);
  }

  

}
