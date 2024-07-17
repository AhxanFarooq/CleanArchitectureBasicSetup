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
    username: '',
    password: ''
  };

  constructor(private authService: AuthService,private router: Router) {}

  onLogin(): void {
    this.authService.login(this.userData).subscribe({
      next: (response) => {
        console.log('Login successful', response);
        localStorage.setItem('token', response.token)
        this.router.navigate(['/main']);
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        console.error('Login failed', error);
        alert('Something went wrong')
        // Handle error
      }
    });
  }
}
