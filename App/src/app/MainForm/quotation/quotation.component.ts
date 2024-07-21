import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { QuotationService } from 'src/app/services/quotation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-quotation',
  templateUrl: './quotation.component.html',
  styleUrls: ['./quotation.component.css']
})
export class QuotationComponent {
  showModel:boolean=false;
  hasPrevPage:boolean=false;
  hasNextPage:boolean=false;
  isUpdate:boolean=false;
  updateId:string='';
  totalCount:number=0;
  totalPages:number = 10;
  pageIndex:number = 1;
  searchValue:string = '';
  quotationColumns: TableColumn[] = [
    {
      key: 'code', title: 'Code', width: '10%',
      buttons: []
    },
    {
      key: 'contactName', title: 'Customer Name', width: '20%',
      buttons: []
    },
    {
      key: 'dateStr', title: 'Date', width: '10%',
      buttons: []
    },
    {
      key: 'dueDateStr', title: 'Due Date', width: '10%',
      buttons: []
    },
    {
      key: 'totalAmount', title: 'Total', width: '10%',
      buttons: []
    },
    {
      key: 'discount', title: 'Discount', width: '10%',
      buttons: []
    },
    {
      key: 'saleTax', title: 'Sale Tax', width: '10%',
      buttons: []
    },
    {
      key: 'netAmount', title: 'Net Amount', width: '10%',
      buttons: []
    },
    { key: 'actions', title: 'Actions',buttons:['edit','del'], isActionColumn: true,width:'15%' }
  ];
  quotations = [
    
  ];
  constructor(private quotationService: QuotationService,private router: Router){

  }

  ngOnInit(){
    this.fetchQuotatios();
  }
  fetchQuotatios() {
    this.quotationService.GetAll( this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.quotations = response.items.map((prod: any)=>({
          id: prod.id,
          code: prod.code,
          contactName: prod.contactName ,
          contactId: prod.contactId ,
          date: prod.date ,
          dateStr: prod.dateStr ,
          dueDateStr: prod.dueDateStr ,
          dueDate: prod.dueDate ,
          totalAmount: prod.totalAmount ,
          discount: prod.discount ,
          saleTax: prod.saleTax ,
          netAmount: prod.netAmount ,
          termAndCondition: prod.termAndCondition ,
          quotationItemModels: prod.quotationItemModels 
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
      }
    });
  }
  OnPageChangeEmit(pageIndex:number){
    this.pageIndex = pageIndex;
    this.fetchQuotatios();
  }
  OnEditEmit(item:any){
    this.EditQuotation(item.id)
  }
  OnDeleteEmit(item:any){
    this.deleteQuotation(item.id);
  }
  AddQuotation(){
    this.router.navigate(['/addQuotation']);
  }

  EditQuotation(id:string){
    
    this.router.navigate(['/addQuotation'], { queryParams: { data: id } });
  }

  deleteQuotation(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this record!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.quotationService.Delete(id).subscribe({
          next: () => {
            this.fetchQuotatios();
        Swal.fire(
          'Deleted!',
          'Your record has been deleted.',
          'success'
        );
            // Handle response, store token, navigate or display a message
          },
          error: (error) => {
            Swal.fire({
              title: 'Something went wrong?',
              text: error,
              icon: 'error'
            })
            // Handle error
          }
        });
        
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your record is safe :)',
          'error'
        );
      }
    });
    
  }
  search() {
    this.quotationService.Search(this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.quotations = response.items.map((prod: any)=>({
          id: prod.id,
          code: prod.code,
          contactName: prod.contactName ,
          contactId: prod.contactId ,
          date: prod.date ,
          dateStr: prod.dateStr ,
          dueDateStr: prod.dueDateStr ,
          dueDate: prod.dueDate ,
          totalAmount: prod.totalAmount ,
          discount: prod.discount ,
          saleTax: prod.saleTax ,
          netAmount: prod.netAmount ,
          termAndCondition: prod.termAndCondition ,
          quotationItemModels: prod.quotationItemModels 
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
}
