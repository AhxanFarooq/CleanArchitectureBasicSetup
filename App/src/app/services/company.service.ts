import { Injectable } from '@angular/core';
import { environments } from '../environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private apiUrl:string = '';
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
    
    return this.http.post(`${this.apiUrl}/Contact/Create`, contactData, this.options)
  }

  public Update(contactData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/Contact/Update`, contactData, this.options)
  }

  public Delete(id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/Contact/Delete?id=${id}`, this.options)
  }

  public GetAll(pageIndex:number, totalPages:number):Observable<any>{
    
    return this.http.get(`${this.apiUrl}/Contact/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }

  public GetById(id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/Contact/GetById?id=${id}`, this.options);
  }
  public Search(search:string,pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/Contact/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }
}
