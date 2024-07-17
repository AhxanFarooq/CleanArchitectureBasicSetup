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

  private apiUrl = environments.apiUrl + '/User';  // Adjust the API URL accordingly

  constructor(private http: HttpClient, private router: Router) { }

  isLoggedIn(): boolean {
    // Implement logic to check if user is logged in
    // For example, you can check if there is a token in local storage
    return !!localStorage.getItem('token');
  }
  signup(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/SignUp`, user);
  }

  login(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/authenticate`, user);
  }

  getBalance(getBalance: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/auth/balance`, getBalance);
  }
}
