import { Injectable } from '@angular/core';
import { environments } from '../environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SetupService {
  private apiUrl:string = ''
  constructor(private http: HttpClient) {
    this. apiUrl = environments.apiUrl;

  }

  public Create(formName: string, setupDate:any):Observable<any>{
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.post(`${this.apiUrl}/${formName}/Create`, setupDate, {headers})
  }

  public GetAll(formName:string, pageIndex:number, totalPages:number):Observable<any>{
    const search = '';
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/${formName}/GetAll?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`, {headers});
  }

  public GetById(formName:string, id:any):Observable<any>{
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/${formName}/GetById?id=${id}`, {headers});
  }
  public Search(formName:string, search:string, pageIndex:number, totalPages:number):Observable<any>{
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/${formName}/GetAll?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`, {headers});
  }

}
