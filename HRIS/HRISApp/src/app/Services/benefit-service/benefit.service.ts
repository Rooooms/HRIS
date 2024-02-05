import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BenefitService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http : HttpClient) { }

   
  getBenefits(): Observable <any> {
    return this.http.get(this.baseApiUrl + 'api/Benefit');
  }


  addBenefits(selectedEmployeeId: string, data :  any): Observable <any> {
    const url = `${this.baseApiUrl}api/Benefit?id=${selectedEmployeeId}`;
    return this.http.post<any>(url, data);
  }

  updateBenefits(id: string, data: any): Observable<any> {
    // Ensure the 'id' property is included in the data payload
    console.log('Update data:', data);
    return this.http.put(`http://localhost:5041/api/Benefit/${id}`, data);
  }

  deleteBenefits(id : string) : Observable<any>{
    return this.http.delete(`http://localhost:5041/api/Benefit/${id}`)
  }
  getBenefitByEmployeeId(selectedEmployeeId : string) : Observable<any>{
    let param1 =  new HttpParams().set('employeeId', selectedEmployeeId)

    return this.http.get(`http://localhost:5041/api/Benefit/`,{params:param1})
  }
}
