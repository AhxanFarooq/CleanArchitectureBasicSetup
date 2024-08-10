import { Component } from '@angular/core';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {
  todayDate:string= new Date().toLocaleDateString();
  companyTitle:string = 'MARTIN DOW MARKER'
  address:string = '7-A, Jail Road, Huda'
  city:string = 'Lahore'
  attention:string = 'Mr. Sajjad Sharif (Associate Manager Packaging Technology)'
  subject:string = ' Quotation of Static Charge Eliminator'
  greeting:string = 'Dear Sir,'
  addressing:string = 'With reference to the meeting in your good office regarding your subject item, we are pleased to offer you our best price with the guarantee of top quality after sales services.'
  price:string = 'PKR 225,000.00'
  termAndCondition:string = '<li><strong>Price validity:</strong> 30 days from the date of quotation</li><li><strong>Payment terms:</strong> 70% Advance and balance at the time of Delivery</li><li><strong>Installation and Training:</strong> Will be done by ECPS Engineer</li><li><strong>Execution Time:</strong> 40-60 Days after Advance Payment</li>'







}
