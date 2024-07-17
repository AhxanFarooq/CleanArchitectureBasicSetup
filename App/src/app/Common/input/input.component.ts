import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent {
 @Input() placeHolder:string='';
 @Input() name:string='';
 @Input() type:string='string';
 @Input() value:any;
 @Input()
 showLabel :boolean=true;
 @Input()
 labelName:string='';
 @Input()
 classcol:string=''
 @Output()
 onInputValueEmit = new EventEmitter<{name:string,type:string,value:any}>()
 ngOnInput()
 {
  console.log(this.type)
 }
 onInputChange(name:string, type:string, value:any){
  this.onInputValueEmit.emit({name:name, type:type,value:value})
 }
}
