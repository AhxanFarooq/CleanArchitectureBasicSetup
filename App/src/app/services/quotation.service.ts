import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environments } from '../environment';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {

  private apiUrl:string = ''
  private options:any;
  constructor(private http: HttpClient) { 
    this. apiUrl = environments.apiUrl
    const token = localStorage.getItem('token'); // Or any other method to retrieve the token

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    this.options = {
      headers: headers
    };
  }

  public Create(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Quotation/Create`, contactData, this.options)
  }

  public Update(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Quotation/Update`, contactData, this.options)
  }

  public Delete(id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/Quotation/Delete?id=${id}`, this.options)
  }
  public GetReportDetail(id:any):Observable<any>{
    return this.http.get( `${this.apiUrl}/Quotation/GetReportDetail?id=${id}`, this.options)
  }

  public GetAll(pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }

  public GetById(id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetById?id=${id}`, this.options);
  }
  public Search(search:string,pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }
  public GetAutoCode():Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetAutoCode`, this.options);
  }
}
