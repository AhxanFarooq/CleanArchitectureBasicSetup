import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environments } from '../environment';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {

  private apiUrl:string = ''
  constructor(private http: HttpClient) { 
    this. apiUrl = environments.apiUrl
  }

  public Create(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Quotation/Create`, contactData)
  }

  public Update(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Quotation/Update`, contactData)
  }

  public Delete(id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/Quotation/Delete?id=${id}`)
  }

  public GetAll(pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }

  public GetById(id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetById?id=${id}`);
  }
  public Search(search:string,pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }
  public GetAutoCode():Observable<any>{
    return this.http.get(`${this.apiUrl}/Quotation/GetAutoCode`);
  }
}
