import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ApexMerchService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }

   
  getApexMerch(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/ApexMerch');
  }


  addApexMerch(selectedEmployeeId: string, data :  any): Observable <any> {
    const url = `${this.baseApiUrl}api/ApexMerch?id=${selectedEmployeeId}`;
    return this.http.post<any>(url, data);
  }

  updateApexMerch(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
    console.log('Update data:', data);
    return this.http.put(`http://localhost:5041/api/ApexMerch/${id}`, data);
  }

  deleteApexMerch(id : string) : Observable<any>{
    return this.http.delete(`http://localhost:5041/api/ApexMerch/${id}`)
  }
  getApexMerchByEmployeeId(selectedEmployeeId : string) : Observable<any>{
    let param1 =  new HttpParams().set('employeeId', selectedEmployeeId)

    return this.http.get(`http://localhost:5041/api/ApexMerch/`,{params:param1})
  }
}
