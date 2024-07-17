import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-textarea',
  templateUrl: './textarea.component.html',
  styleUrls: ['./textarea.component.css']
})
export class TextareaComponent {
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
  onInputChange(name:string,type:string, value:any){
   this.onInputValueEmit.emit({name:name,type:type,value:value})
  }
}
