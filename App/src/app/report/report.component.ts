import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {
  @Input() quotationReport: QuotationReport = new QuotationReport();
}

export class QuotationReport{
  TodayDate:string= new Date().toLocaleDateString();
  CompanyTitle:string = 'MARTIN DOW MARKER'
  Address:string = '7-A, Jail Road, Huda'
  City:string = 'Lahore'
  Attention:string = 'Mr. Sajjad Sharif (Associate Manager Packaging Technology)'
  Subject:string = ' Quotation of Static Charge Eliminator'
  Greeting:string = 'Dear Sir,'
  Addressing:string = 'With reference to the meeting in your good office regarding your subject item, we are pleased to offer you our best price with the guarantee of top quality after sales services.'
  Price:string = 'PKR 225,000.00'
  ProductName:string = 'Static Charge Eliminator'
  TermAndCondition:string = '<li><strong>Price validity:</strong> 30 days from the date of quotation</li><li><strong>Payment terms:</strong> 70% Advance and balance at the time of Delivery</li><li><strong>Installation and Training:</strong> Will be done by ECPS Engineer</li><li><strong>Execution Time:</strong> 40-60 Days after Advance Payment</li>'
  ProductDescription:string = `<ul>
        <li><strong>Model:</strong> CDI-106IB</li>
        <li><strong>Input voltage:</strong> AC220V single phase 50/60Hz</li>
        <li><strong>Output voltage:</strong> 7kW</li>
        <li><strong>Working power:</strong> 50W</li>
        <li><strong>Best working distance:</strong> 5-15CM</li>
        <li><strong>One Eliminator with two bars</strong></li>
        <li><strong>Eliminating bar:</strong> 106B-10</li>
        <li><strong>Effective length:</strong> 200mm</li>
        <li><strong>Total length:</strong> 300mm</li>
      </ul>`;
  User:string= 'M. Shahid Imran';
  UserDesignation:string = 'CEO';
  productImage:string = ''
}
