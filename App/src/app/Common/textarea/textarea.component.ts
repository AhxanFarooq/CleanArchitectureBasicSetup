import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';

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
  isRichTextArea :boolean=false;
  @Input()
  labelName:string='';
  @Input()
  classcol:string=''
  @Output()
  onInputValueEmit = new EventEmitter<{name:string,type:string,value:any}>()
  ngOnInput()
  {
   console.log(this.isRichTextArea)
  }
  onInputChange(name:string,type:string, value:any){
   this.onInputValueEmit.emit({name:name,type:type,value:value})
  }
  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '10rem',
    minHeight: '5rem',
    placeholder: 'Terms And Conditions...',
    translate: 'no',
    customClasses: [
      {
        name: "quote",
        class: "quote",
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ]
  }
}
