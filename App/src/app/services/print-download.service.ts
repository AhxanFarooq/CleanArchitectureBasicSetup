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
    if (data != null) {
      const printWindow = window.open('', '', 'height=600,width=800');;
      if (printWindow) {
        // Write HTML structure to the new window
        printWindow.document.write('<html><head><title>Print</title>');
        printWindow.document.write('<link rel="stylesheet" type="text/css" href="style.css">');
        printWindow.document.write('</head><body>');

        // Add a header with an image at the right corner
        printWindow.document.write('<header style="position: fixed; top: 0; left: 0; width: 100%; height: 100px; padding: 10px; box-sizing: border-box;">');
        printWindow.document.write('<img src="assets/images/exalted.png" style="height: 70px; float: right;" alt="Logo">');
        printWindow.document.write('</header>');

        // Add the content you want to print
        printWindow.document.write('<div style="margin-top: 100px;">');
        printWindow.document.write(data.innerHTML);
        printWindow.document.write('</div>');

        // Add footer content, you can customize this
        printWindow.document.write('<footer style="position: fixed; bottom: 0; left: 0; width: 100%; text-align: center;">');
        printWindow.document.write('<p style="font-size:13px;color:red">1st Floor 949-B Block, Faisal Town, Maulana Shaukat Ali Road - Lahore, Tel: 042-35126697, Email: info@exalted.com.pk</p>');
        printWindow.document.write('</footer>');

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

    if (data != null) {
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
