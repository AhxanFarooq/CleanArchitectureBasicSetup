// src/app/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environments} from '../environment'
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = environments.apiUrl + '/Authentication';  // Adjust the API URL accordingly

  constructor(private http: HttpClient, private router: Router) { }

  isLoggedIn(): boolean {
    const tokenData = sessionStorage.getItem('authToken');
    if (!tokenData) return false;

    const parsedToken = JSON.parse(tokenData);
    if (new Date().getTime() > parsedToken.expiry) {
      sessionStorage.removeItem('authToken') // Token expired, remove it
      return false;
    }

    return true;
  }
  signup(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/Register`, user);
  }

  login(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/Login`, user);
  }

}
