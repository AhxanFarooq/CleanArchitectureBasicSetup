import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.css']
})
export class BalanceComponent {
  totalBalance = 0;
  getBalance = {
    token: localStorage.getItem('token')
  };
  constructor(private authService: AuthService) {}
  onGetBalance(): void {

    this.authService.getBalance(this.getBalance).subscribe({
      next: (response) => {
        console.log('Get Record', response);
        this.totalBalance = response.balance
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        console.error('Get Record failed', error);
        alert('Something went wrong')
        // Handle error
      }
    });
  }
}
