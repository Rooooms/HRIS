import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequirementService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }


  getRequirement(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/Requirement');
  }

  addRequirement(selectedEmployeeId: string, data :  any): Observable <any> {
    const url = `${this.baseApiUrl}api/Requirement?id=${selectedEmployeeId}`;
    return this.http.post<any>(url, data);
  }

  updateRequirement(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
    console.log('Update data:', data);
    return this.http.put(`http://localhost:5041/api/Requirement/${id}`, data);
  }

  getRequirementByEmployeeId(selectedEmployeeId : string) : Observable<any>{
    let param1 =  new HttpParams().set('employeeId', selectedEmployeeId)

    return this.http.get(`http://localhost:5041/api/Requirement/`,{params:param1})
  }
}
