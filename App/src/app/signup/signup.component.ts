// src/app/signup/signup.component.ts
import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  user = {
    email: '',
    password: '',
    name: '',
    address: '',
    mobile_Phone: '',
    user_Role: ''
  };

  constructor(private authService: AuthService,private router: Router) {}

  onSignup(): void {
    this.authService.signup(this.user).subscribe({
      next: (response) => {
        console.log('Signup successful', response);
        alert('Signup Successfully');
        this.resetForm();
        this.router.navigate(['/login']);
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
      email: '',
      password: '',
      name: '',
      address: '',
      mobile_Phone: '',
      user_Role: ''
    };
  }
}

