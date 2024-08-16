import { Component, Input } from '@angular/core';
import { QuotationReport } from '../report.component';

@Component({
  selector: 'app-quotation-report-multiple-item',
  templateUrl: './quotation-report-multiple-item.component.html',
  styleUrls: ['./quotation-report-multiple-item.component.css']
})
export class QuotationReportMultipleItemComponent {
  @Input() quotationReport: QuotationReport = new QuotationReport();
  User:string= 'M. Shahid Imran';
  UserDesignation:string = 'CEO';
}

