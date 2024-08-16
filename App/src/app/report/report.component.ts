import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent {
  @Input() quotationReport: QuotationReport = new QuotationReport();
  User:string= 'M. Shahid Imran';
  UserDesignation:string = 'CEO';
}

export class QuotationReport{
  TodayDate:string= '';
  CompanyTitle:string = ''
  Address:string = ''
  City:string = ''
  Attention:string = ''
  Subject:string = ''
  Greeting:string = ''
  Addressing:string = ''
  Price:string = ''
  ProductName:string = ''
  TermAndCondition:string = ''
  ProductDescription:string = '';
  ProductImage:string = ''
  quotationReportItemModels: QuotationReportItemModel[] = [];
}
export class QuotationReportItemModel{
  name:string= '';
  lineTotal: string = '';
  imagePath:string = ''
}