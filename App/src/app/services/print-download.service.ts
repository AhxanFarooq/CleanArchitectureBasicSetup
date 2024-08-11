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
     // Write the HTML structure to the new window
    printWindow.document.write('<html><head><title>Print</title>');
    printWindow.document.write('<link rel="stylesheet" type="text/css" href="style.css">');
    printWindow.document.write('<style>');
    
    // Print-specific styles
    printWindow.document.write(`
        @media print {
            // @page {
            //     margin: 12px 24px 12px 24px; /* Remove default margins */
            // }

            body {
                //margin: 0 24px 0 24px;
                //padding: 0;
                font-family: 'Times New Roman', Times, serif;
            }

            header {
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100px;
                padding: 10px;
                box-sizing: border-box;
                z-index: 1000;
                background-color: #fff;
            }

            footer {
                position: fixed;
                bottom: 0;
                left: 0;
                width: 100%;
                text-align: center;
                background-color: #fff;
                z-index: 1000;
                font-size: 13px;
                color: red;
            }

            .content {
             
                padding-top: 40px; /* Ensure content starts below the header */
                padding-bottom: 0px; /* Ensure content ends above the footer */
                box-sizing: border-box;
                width: 100%;
            }

            .content * {
                page-break-inside: auto !important;
                overflow: visible !important;
            }

            .page-break {
                page-break-before: always;
                margin-top: 100px
            }

            /* Ensuring content isn't hidden under header or footer */
            .content::after {
                display: block;
                content: '';
                height: 1px;
                margin-bottom: 120px;
                box-sizing: border-box;
            }
            
        }
                /* Hide the second page if content is small enough to fit on one page */
            @media print and (max-height: 297mm) { /* A4 page height in portrait mode */
                footer {
                    position: absolute; /* Change to absolute to avoid pushing content */
                }
            }
    `);
    
    printWindow.document.write('</style>');
    printWindow.document.write('</head><body>');

    // Add a header with an image at the right corner
    printWindow.document.write('<header>');
    printWindow.document.write('<img src="assets/images/exalted.png" style="height: 70px; float: right;" alt="Logo">');
    printWindow.document.write('</header>');

    // Add the content you want to print
    printWindow.document.write('<div class="content">');
    printWindow.document.write(data.innerHTML);
    printWindow.document.write('</div>');

    // Add footer content, you can customize this
    printWindow.document.write('<footer>');
    printWindow.document.write('<p>1st Floor 949-B Block, Faisal Town, Maulana Shaukat Ali Road - Lahore, Tel: 042-35126697, Email: info@exalted.com.pk</p>');
    printWindow.document.write('</footer>');

    // Close the document and trigger the print
    printWindow.document.write('</body></html>');
    printWindow.document.close();  // Close the document to finish writing to it
    printWindow.focus();  // Focus the new window

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
