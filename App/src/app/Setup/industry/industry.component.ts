import { Component, ViewChild, Renderer2, ElementRef } from '@angular/core';
import {SetupService} from '../../services/setup.service'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-industry',
  templateUrl: './industry.component.html',
  styleUrls: ['./industry.component.css']
})
export class IndustryComponent {
  @ViewChild('modalElement')
  modalElement!: ElementRef;
  industrys: Industry[] = []; // Initialize with sample data or fetch from a service
  newIndustry: Industry = {id:'', name: '', description: '', isActive: true };
  searchValue:string='';
  totalPages:number = 10;
  pageIndex:number = 1;
  totalCount:number = 0;
  hasPrevPage:boolean = false;
  hasNextPage:boolean = false;

  constructor(private setupService: SetupService,private renderer: Renderer2) { }

  ngOnInit(): void {
    this.fetchIndustrys()
    // Initialize industrys array with sample data or fetch from a service
  }
  onPageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.fetchIndustrys();
  }
  fetchIndustrys() {
    this.setupService.GetAll("Industry", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.industrys = response.items.map((industry: Industry)=>({
          id: industry.id,
          name: industry.name,
          description: industry.description,
          isActive: industry.isActive
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
  search() {
    this.setupService.Search("Industry",this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.industrys = response.items.map((industry: Industry)=>({
          id: industry.id,
          name: industry.name,
          description: industry.description,
          isActive: industry.isActive
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
  editIndustry() {
    this.setupService.Update("Industry",this.newIndustry).subscribe({
      next: () => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchIndustrys();
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

  close() {
    // Close the modal by setting its 'display' style property to 'none'
    const closeButton = this.modalElement.nativeElement.querySelector('[data-bs-dismiss="modal"]');
    closeButton.click();
  }
  open(){
          
    if (this.modalElement) {
      const closeButton = this.modalElement.nativeElement.querySelector('[data-bs-target="modal"]');
    closeButton.click();
      // const modal = new bootstrap.Modal(this.modalElement.nativeElement, {
      //   keyboard: false
      // });
      // modal.show();
    } else {
      console.error('Button element not found');
    }
  }
  addIndustry() {
    this.setupService.Create("Industry",this.newIndustry).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchIndustrys();
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
  clearObject(){
    this.newIndustry.id = '';
    this.newIndustry.description = '';
    this.newIndustry.isActive = true;
    this.newIndustry.name = '';
  }
  getIndustry(id:string) {
    this.setupService.GetById("Industry",id).subscribe({
      next: (response) => {
        this.newIndustry.id = response.id;
        this.newIndustry.description = response.description;
        this.newIndustry.isActive = response.isActive;
        this.newIndustry.name = response.name;
        this.open()
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
  updateIndustry() {
    this.setupService.Update("Industry",this.newIndustry).subscribe({
      next: () => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.close();
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

  deleteIndustry(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this record!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.setupService.Delete("Industry",id).subscribe({
          next: (response) => {
            this.fetchIndustrys();
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

export class Industry{
  id:string = ''
  name:string = ''
  description:string =''
  isActive:boolean= true

}
