import { Component, ViewChild, Renderer2, ElementRef } from '@angular/core';
import {SetupService} from '../../services/setup.service'
import Swal from 'sweetalert2';
@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css']
})
export class AreaComponent {
  @ViewChild('modalElement')
  modalElement!: ElementRef;
  areas: Area[] = []; // Initialize with sample data or fetch from a service
  newArea: Area = {id:'', name: '', description: '', isActive: true };
  searchValue:string=''
  totalPages:number = 10;
  pageIndex:number = 1;
  totalCount:number = 0;
  hasPrevPage:boolean = false;
  hasNextPage:boolean = false;

  constructor(private setupService: SetupService,private renderer: Renderer2) { }

  ngOnInit(): void {
    this.fetchAreas()
    // Initialize areas array with sample data or fetch from a service
  }
  onPageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.fetchAreas();
  }
  fetchAreas() {
    this.setupService.GetAll("Area", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.areas = response.items.map((area: Area)=>({
          id: area.id,
          name: area.name,
          description: area.description,
          isActive: area.isActive
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
    this.setupService.Search("Area",this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.areas = response.items.map((area: Area)=>({
          id: area.id,
          name: area.name,
          description: area.description,
          isActive: area.isActive
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
  editArea() {
    this.setupService.Update("Area",this.newArea).subscribe({
      next: () => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchAreas();
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
  addArea() {
    this.setupService.Create("Area",this.newArea).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchAreas();
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
    this.newArea.id = '';
    this.newArea.description = '';
    this.newArea.isActive = true;
    this.newArea.name = '';
  }
  getArea(id:string) {
    this.setupService.GetById("Area",id).subscribe({
      next: (response) => {
        this.newArea.id = response.id;
        this.newArea.description = response.description;
        this.newArea.isActive = response.isActive;
        this.newArea.name = response.name;
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
  updateArea() {
    this.setupService.Update("Area",this.newArea).subscribe({
      next: (response) => {
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

  deleteArea(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this record!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.setupService.Delete("Area",id).subscribe({
          next: () => {
            this.fetchAreas();
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

export class Area{
  id:string = ''
  name:string = ''
  description:string =''
  isActive:boolean= true

}