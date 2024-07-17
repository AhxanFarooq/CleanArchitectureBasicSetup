import { Component } from '@angular/core';
import {CompanyService} from '../../services/company.service'
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent {
  constructor(private companyService: CompanyService,private router: Router) { }
  contacts: Contact[] = []; 
  searchValue:string = '';
  totalPages:number = 10;
  pageIndex:number = 1;
  totalCount:number = 0;
  hasPrevPage:boolean = false;
  hasNextPage:boolean = false;
  ngOnInit(): void {
    this.fetchContacts()
    // Initialize areas array with sample data or fetch from a service
  }
  onPageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.fetchContacts();
  }
  fetchContacts() {
    this.companyService.GetAll(this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.contacts = response.items.map((contact: Contact)=>({
          id: contact.id,
          companyTitle: contact.companyTitle,
          city: contact.city,
          areaId:contact.areaId,
          industryId:contact.industryId,
          areaName: contact.areaName,
          industryName: contact.industryName,
          address: contact.address,
          googleMapLink:contact.googleMapLink,
          source: contact.source
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
  search() {
    this.companyService.Search(this.searchValue,1, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.contacts = response.items.map((contact: Contact)=>({
          id: contact.id,
          companyTitle: contact.companyTitle,
          city: contact.city,
          areaId:contact.areaId,
          industryId:contact.industryId,
          areaName: contact.areaName,
          industryName: contact.industryName,
          address: contact.address,
          googleMapLink:contact.googleMapLink,
          source: contact.source
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

  AddNew(){
    
    this.router.navigate(['/addContact']);
  }
  EditContact(id:string){
    
    this.router.navigate(['/addContact'], { queryParams: { data: id } });
  }

  deleteContact(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this record!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.companyService.Delete(id).subscribe({
          next: () => {
            this.fetchContacts();
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
}

export class Contact{
  id:string='00000000-0000-0000-0000-000000000000'
  companyTitle:string='' 
  city:string=''
  areaId:string='00000000-0000-0000-0000-000000000000'
  industryId:string='00000000-0000-0000-0000-000000000000'
  address:string=''
  googleMapLink:string=''
  source:string=''
  areaName:string=''
  industryName:string=''
  contactDetailModels: ContactDetailModel[]= []
  contactCoversationModels:ContactCoversationModel[]= []

}

export class ContactDetailModel{
  id:string='00000000-0000-0000-0000-000000000000' 
  name:string='' 
  email:string='' 
  secondary_Email:string='' 
  phone:string='' 
  secondary_Phone:string='' 
  designation:string='' 
  contactId:string='00000000-0000-0000-0000-000000000000' 
}

export class ContactCoversationModel{
  id:string='00000000-0000-0000-0000-000000000000'
  note:string=''
  contactId:string='00000000-0000-0000-0000-000000000000'
}