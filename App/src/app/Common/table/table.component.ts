import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {
  @Input() data: any[] = [];
  @Input() columns: TableColumn[] = []; // Array of property names
  @Input() totalCount:number = 0;
  @Input() hasPrevPage:boolean = false;
  @Input() hasNextPage:boolean = false;

  @Output()
  OnPageChangeEmit = new EventEmitter<number>();
  @Output()
  OnEditEmit = new EventEmitter<any>();
  @Output()
  OnDeleteEmit = new EventEmitter<any>();

  constructor() {}


  onEdit(item: any) {
    this.OnEditEmit.emit(item);
  }
  
  onDelete(item: any) {
    this.OnDeleteEmit.emit(item);
  }
  onPageChange(pageIndex: number): void {
    this.OnPageChangeEmit.emit(pageIndex);
  }
}
