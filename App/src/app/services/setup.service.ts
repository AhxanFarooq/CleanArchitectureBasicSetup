import { Injectable } from '@angular/core';
import { environments } from '../environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SetupService {
  private apiUrl:string = ''
  constructor(private http: HttpClient) { 
    this. apiUrl = environments.apiUrl + '/Setup'
  }

  public Create(formName: string, setupDate:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/${formName}/Create`, setupDate)
  }

  public Update(formName:string, setupData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/${formName}/Update`, setupData)
  }

  public Delete(formName:string, id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/${formName}/Delete?id=${id}`)
  }

  public GetAll(formName:string, pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }

  public GetById(formName:string, id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/GetById?id=${id}`);
  }
  public Search(formName:string, search:string, pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`);
  }

}
