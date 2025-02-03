import { Component, ViewChild, Renderer2, ElementRef } from '@angular/core';
import {SetupService} from '../../services/setup.service'
import Swal from 'sweetalert2';
@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent {
  @ViewChild('modalElement')
  modalElement!: ElementRef;
  patients: Patient[] = []; // Initialize with sample data or fetch from a service
  newPatient: Patient = {id:'00000000-0000-0000-0000-000000000000',code:'', name: '', dateOfBirth: '', contactInfo: '', status: ''};
  searchValue:string=''
  totalPages:number = 10;
  pageIndex:number = 1;
  totalCount:number = 0;
  hasPrevPage:boolean = false;
  hasNextPage:boolean = false;

  private modalInstance: any;
  isViewMode:boolean = false;


  constructor(private setupService: SetupService,private renderer: Renderer2) { }

  ngOnInit(): void {
    this.fetchPatients()
  }
  ngAfterViewInit() {
    this.modalInstance = new (window as any).bootstrap.Modal(this.modalElement.nativeElement);
  }
  onPageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.fetchPatients();
  }
  fetchPatients() {
    this.setupService.GetAll("Patient", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.patients = response.items.map((data: Patient)=>({
          id: data.id,
          code: data.code,
          name: data.name,
          dateOfBirth: data.dateOfBirth,
          contactInfo: data.contactInfo,
          status: data.status,
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error.error.error,
          icon: 'error'
        })
      }
    });
  }
  search() {
    this.setupService.Search("Patient",this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.patients = response.items.map((data: Patient)=>({
          id: data.id,
          code: data.code,
          name: data.name,
          dateOfBirth: data.dateOfBirth,
          contactInfo: data.contactInfo,
          status: data.status,
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error.error.error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }

  close() {
    // Close the modal by setting its 'display' style property to 'none'

    this.isViewMode = false;
    this.modalInstance.hide();

  }
  open(){

    if (this.modalElement) {
      this.modalInstance.show();

    } else {
      console.error('Button element not found');
    }
  }
  addPatient() {
    this.isViewMode = false;
    this.setupService.Create("Patient",this.newPatient).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchPatients();
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error.error.error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
  clearObject(){
    this.newPatient.id = '00000000-0000-0000-0000-000000000000';
    this.newPatient.code = '';
    this.newPatient.name = '';
    this.newPatient.dateOfBirth = '';
    this.newPatient.contactInfo = '';
    this.newPatient.status = '';
  }
  getPatient(id:string) {
    this.setupService.GetById("Patient",id).subscribe({
      next: (response) => {
        this.newPatient.id = response.id;
        this.newPatient.code = response.code;
        this.newPatient.dateOfBirth = response.dateOfBirth;
        this.newPatient.contactInfo = response.contactInfo;
        this.newPatient.status = response.status;
        this.newPatient.name = response.name;
        this.isViewMode = true;
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



}

export class Patient{
  id:string = '00000000-0000-0000-0000-000000000000'
  code:string = ''
  name:string = ''
  dateOfBirth:string =''
  contactInfo:string= ''
  status:string= ''

}
