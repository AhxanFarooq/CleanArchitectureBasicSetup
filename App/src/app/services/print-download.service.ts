import { Injectable } from '@angular/core';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Injectable({
  providedIn: 'root'
})
export class PrintDownloadService {

  constructor() { }

  printReport(contentId: string): void {
    
    const data = document.getElementById(contentId);
    if(data != null){
      const printWindow = window.open('', '_blank');
      if(printWindow){
        printWindow.document.write('<html><head><title>Print</title><link rel="stylesheet" type="text/css" href="style.css"></head><body>');
        printWindow.document.write(data.innerHTML);
        printWindow.document.write('</body></html>');
        printWindow.document.close();
        printWindow.focus();

        // Use timeout to ensure rendering happens before print
        setTimeout(() => {
          printWindow.print();
          printWindow.close();
        }, 250);
      }
      else {
        console.error('Failed to open the print window');
      }
      
    }
  }

  downloadPDF(contentId: string): void {
    const data = document.getElementById(contentId);

    if(data != null){
      html2canvas(data).then(canvas => {
        const imgWidth = 208;
        const imgHeight = canvas.height * imgWidth / canvas.width;
        const contentDataURL = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');
        pdf.addImage(contentDataURL, 'PNG', 0, 0, imgWidth, imgHeight);
        pdf.save('downloaded-file.pdf');
      });
    }
  }
}
