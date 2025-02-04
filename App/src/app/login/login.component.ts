// src/app/login/login.component.ts
import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  userData = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService,private router: Router) {}

  onLogin(): void {
    this.authService.login(this.userData).subscribe({
      next: (response) => {
        console.log('Login successful', response);
        this.setToken(response.token, response.expiryTime);
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.error('Login failed', error);
        alert('Something went wrong')
        // Handle error
      }
    });
  }
  setToken(token: string, expiryInMinutes: number): void {
    const expiryTime = new Date().getTime() + expiryInMinutes * 60 * 1000; // Convert minutes to milliseconds
    const tokenData = {
      value: token,
      expiry: expiryTime
    };
    sessionStorage.setItem('authToken', JSON.stringify(tokenData));
  }
}
