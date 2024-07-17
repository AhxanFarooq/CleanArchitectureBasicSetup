import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent {
  @Input() items: Array<{name: string, id: string}> = [];
  @Output() selectionChange = new EventEmitter<any>();
  @Input() label:string='';
  @Input() showLabel:boolean=true;

  selectedValue: any;

  onChange(event: Event) {
    const target = event.target as HTMLSelectElement;  // Type assertion
    if (target && target.value) {
      this.selectionChange.emit(target.value);
    }
  }
}
