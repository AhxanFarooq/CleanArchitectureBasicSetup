import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnChanges {
  @Input() totalItems: number = 0;
  @Input() itemsPerPage: number = 10;
  @Input() hasPrevPage:boolean = false;
  @Input() hasNextPage:boolean = false;
  @Output() pageChanged = new EventEmitter<number>();

  pageNumber:number=0;
  pageSize:number=10;
  currentPage: number = 1;
  totalPages: number =0;

  ngOnChanges(): void {
    this.totalPages = Math.ceil(this.totalItems / this.itemsPerPage);
  }

  selectPage(page: number): void {
    if (page < 1 || page > this.totalPages) return;
    this.currentPage = page;
    this.pageChanged.emit(this.currentPage);
  }
  nextPage(){
    this.currentPage++;
    this.pageChanged.emit(this.currentPage);
  }
  prevPage(){
    this.currentPage--;
    this.pageChanged.emit(this.currentPage);
  }
  openLastPage(){
    this.currentPage = this.totalPages;
    this.pageChanged.emit(this.currentPage);
  }
  openFirstPage(){
    this.currentPage = 1;
    this.pageChanged.emit(this.currentPage);
  }
  openSelectedPage(page:number){
    this.currentPage = page;
    this.pageChanged.emit(this.currentPage);
  }
  openSpecificPage(){
    var total = (this.pageNumber > 0? this.pageNumber -1 : this.pageNumber)* this.itemsPerPage;
    
    if(total >=  this.totalItems){
      alert('Page Number Exceded its limit')
      // Swal.fire({
      //   title: 'Page Number Exceded',
      //   text: 'You entered wrong page number',
      //   icon: 'error',
      //   timerProgressBar:true,
      //   timer:1500
      // }).then(result => {
      //   console.log(result)
      // });
    }
    else if(total <= 0){
      alert('Enter page number greator than zero')
      // Swal.fire({
      //   title: 'NegativePage Number',
      //   text: 'Enter page number greator than zero',
      //   icon: 'error'
      // })
    }
    else{
      this.currentPage = this.pageNumber
      this.pageChanged.emit(this.currentPage);
    }
  }
}
