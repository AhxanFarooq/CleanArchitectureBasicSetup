import { Injectable } from '@angular/core';
import { environments } from '../environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SetupService {
  private apiUrl:string = ''
  private options:any;
  constructor(private http: HttpClient) { 
    this. apiUrl = environments.apiUrl + '/Setup';
    const token = localStorage.getItem('token'); // Or any other method to retrieve the token

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    this.options = {
      headers: headers
    };
  }

  public Create(formName: string, setupDate:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/${formName}/Create`, setupDate, this.options)
  }

  public Update(formName:string, setupData:any):Observable<any>{
    return this.http.post(`${this.apiUrl}/${formName}/Update`, setupData, this.options)
  }

  public Delete(formName:string, id:any):Observable<any>{
    return this.http.delete( `${this.apiUrl}/${formName}/Delete?id=${id}`, this.options)
  }

  public GetAll(formName:string, pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/GetAll?pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }

  public GetById(formName:string, id:any):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/GetById?id=${id}`, this.options);
  }
  public Search(formName:string, search:string, pageIndex:number, totalPages:number):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/Search?search=${search}&pageIndex=${pageIndex}&totalPages=${totalPages}`, this.options);
  }
  public ImageUploader(formName:string, imageData:FormData):Observable<any>{
    return this.http.post(`${this.apiUrl}/${formName}/UploadFilesAsync`, imageData, this.options);
  }
  public GetBase64Image(formName:string, path:string):Observable<any>{
    return this.http.get(`${this.apiUrl}/${formName}/GetBase64ImagePath?path=${path}`, this.options);
  }

}
