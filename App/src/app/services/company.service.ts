import { Injectable } from '@angular/core';
import { environments } from '../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private apiUrl:string = ''
  constructor(private http: HttpClient) { 
    this. apiUrl = environments.apiUrl
  }

  public Create(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Contact/Create`, contactData)
  }

  public Update(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Contact/Update`, contactData)
  }

  public Delete(id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/Contact/Delete?id=${id}`)
  }

  public GetAll(pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Contact/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }

  public GetById(id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/Contact/GetById?id=${id}`);
  }
  public Search(search:string,pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Contact/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }
}
