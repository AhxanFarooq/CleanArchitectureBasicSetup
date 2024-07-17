// src/app/signup/signup.component.ts
import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  user = {
    userName: '',
    password: '',
    firstName: '',
    lastName: '',
    device: '',
    ipAddress: ''
  };

  constructor(private authService: AuthService) {}

  onSignup(): void {
    this.authService.signup(this.user).subscribe({
      next: (response) => {
        console.log('Signup successful', response);
        alert('Signup Successfully');
        this.resetForm();
        // Handle successful signup, such as redirecting to a login page or showing a success message
      },
      error: (error) => {
        console.error('Signup failed', error);
        alert('Something went wrong')
        // Handle error, such as displaying an error message to the user
      }
    });
  }

  resetForm(): void {
    this.user = {
      userName: '',
      password: '',
      firstName: '',
      lastName: '',
      device: '',
      ipAddress: ''
    };
  }
}

