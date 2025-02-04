import { Component, ViewChild, Renderer2, ElementRef } from '@angular/core';
import {SetupService} from '../../services/setup.service'
import Swal from 'sweetalert2';
import { Patient } from '../patient/patient.component';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.css']
})
export class RecommendationComponent {
  @ViewChild('modalElement')
  modalElement!: ElementRef;
  recommendations: Recommendation[] = []; // Initialize with sample data or fetch from a service
  newRecommendation: Recommendation = {id:'00000000-0000-0000-0000-000000000000', type: '', dueDate: '', status: '', patientId:'' };
  searchValue:string='';
  totalPages:number = 10;
  pageIndex:number = 1;
  totalCount:number = 0;
  hasPrevPage:boolean = false;
  hasNextPage:boolean = false;
  private modalInstance: any;
  patients: Patient[] = [];

  constructor(private setupService: SetupService,private renderer: Renderer2) { }

  ngOnInit(): void {
    this.fetchRecommendations()
    this.fetchPatients();
    // Initialize recommendations array with sample data or fetch from a service
  }
  onPageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.fetchRecommendations();
  }
  fetchRecommendations() {
    this.setupService.GetAll("Recommendation", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.recommendations = response.items.map((recommendation: Recommendation)=>({
          id: recommendation.id,
          type: recommendation.type,
          dueDate: recommendation.dueDate,
          status: recommendation.status,
          patientId: recommendation.patientId
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
    this.setupService.Search("Recommendation",this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.recommendations = response.items.map((recommendation: Recommendation)=>({
          id: recommendation.id,
          type: recommendation.type,
          dueDate: recommendation.dueDate,
          status: recommendation.status,
          patientId: recommendation.patientId
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

  UpdateStatus(id:any){
    var data = this.recommendations.find(x=>x.id == id);

    if(data){
      data.status = 'Completed';
      this.setupService.Create("Recommendation",data).subscribe({
        next: () => {
          Swal.fire({
            title: "Saved!",
            text: "Updated status successfully!",
            icon: "success"
          });
          this.close();
          this.clearObject();
          this.fetchRecommendations();
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


  close() {
    this.modalInstance.hide();

  }
  open(){

    if (this.modalElement) {
      this.modalInstance.show();

    } else {
      console.error('Button element not found');
    }
  }
  addRecommendation() {
    this.setupService.Create("Recommendation",this.newRecommendation).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.close();
        this.clearObject();
        this.fetchRecommendations();
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
    this.newRecommendation.id = '00000000-0000-0000-0000-000000000000';
    this.newRecommendation.type = '';
    this.newRecommendation.dueDate = '';
    this.newRecommendation.status = '';
    this.newRecommendation.patientId = '';
  }
  getRecommendation(id:string) {
    this.setupService.GetById("Recommendation",id).subscribe({
      next: (response) => {
        this.newRecommendation.id = response.id;
        this.newRecommendation.type = response.type;
        this.newRecommendation.status = response.status;
        this.newRecommendation.patientId = response.patientId;
        this.newRecommendation.dueDate = response.dueDate;
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

  fetchPatients() {
      this.setupService.GetAll("Patient", this.pageIndex, this.totalPages).subscribe({
        next: (response) => {
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


}

export class Recommendation{
  id:string = '00000000-0000-0000-0000-000000000000'
  type:string = ''
  dueDate:string =''
  status:string= ''
  patientId:string= ''

}
