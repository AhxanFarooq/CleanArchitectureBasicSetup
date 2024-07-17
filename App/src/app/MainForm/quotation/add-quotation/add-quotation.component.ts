import { Component } from '@angular/core';
import { Contact } from '../../company/company.component';
import { CompanyService } from 'src/app/services/company.service';
import Swal from 'sweetalert2';
import { SetupService } from 'src/app/services/setup.service';

@Component({
  selector: 'app-add-quotation',
  templateUrl: './add-quotation.component.html',
  styleUrls: ['./add-quotation.component.css']
})
export class AddQuotationComponent {

  constructor(private companyService:CompanyService, private setupService:SetupService){
    this.fetchContacts();
    this.fetchProducts();
  }

  pageIndex:number=0;
  totalPages:number=0;
  labelContactDropdown:string='Contact';
  labelProductDropdown:string='Product';
  items:Array<{name: string, id: string}> = [];
  productItems:Array<{name: string, id: string}> = [];

  fetchContacts() {
    this.companyService.GetAll(this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.items = response.items.map((contact: Contact)=>({
          id: contact.id,
          name: contact.companyTitle
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
  fetchProducts() {
    this.setupService.GetAll("Product", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.productItems = response.items.map((prod: any)=>({
          id: prod.id,
          name: prod.name
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
  onDateEmit(eventData: { name: string,type:string, value: any }){
    
    console.log(eventData);
  }
  onDueDateEmit(eventData: { name: string,type:string, value: any }){
    
    console.log(eventData);
  }

  onDropdownChange(selectedValue: any) {
    console.log('Contact Selected Value:', selectedValue);
  }
  onProductDropdownChange(selectedValue: any) {
    console.log('Product Selected Value:', selectedValue);
  }
}
