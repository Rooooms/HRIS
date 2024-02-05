import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EducationalBgService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }


  getEducationalBg(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/EducationalBg');
  }

  addEducationalBG(selectedEmployeeId: string, data :  any): Observable <any> {
    const url = `${this.baseApiUrl}api/EducationalBg?id=${selectedEmployeeId}`;
    return this.http.post<any>(url, data);
  }

  updateEducationalBG(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
    console.log('Update data:', data);
    return this.http.put(`http://localhost:5041/api/EducationalBg/${id}`, data);
  }

  getEducationalBgByEmployeeId(selectedEmployeeId : string) : Observable<any>{
    let param1 =  new HttpParams().set('employeeId', selectedEmployeeId)

    return this.http.get(`http://localhost:5041/api/EducationalBg/`,{params:param1})
  }

}
