import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @ViewChild('modalElement', { static: true })
  modalElement!: ElementRef;
  private modalInstance: any;

  @Input()
  formDetail !: FormDetail[] ;
  @Input()
  formTitle : string="Modal Tite" ;

  @Output()
  fieldDataEmit = new EventEmitter<Map<string, any>>();

  fieldData: Map<string, any> = new Map<string, any>();

  ngOnInit(){
    this.setFieldData()
  }

  setFieldData(){
    for(const item of this.formDetail)
      {
        this.fieldData.set(item.name,item.value);
      }
  }


  ngAfterViewInit() {
    this.modalInstance = new (window as any).bootstrap.Modal(this.modalElement.nativeElement);
  }

  static nativeElement: any;

  show(): void {
    this.modalInstance.show();
    this.setFieldData();
  }
  hide() {
    this.modalInstance.hide();
  }

  validateInputField(type:string){
    return type.toLowerCase() === 'string' || type.toLocaleLowerCase() === 'number'
  }
  validateTextAreaField(type:string){
    return type.toLowerCase() === 'textarea'
  }
  saveRecord(){
    this.fieldDataEmit.emit(this.fieldData);
  }
  onInputValueEmit(eventData: { name: string,type:string, value: any }){
    if(eventData.type === 'number')
      eventData.value = parseFloat(eventData.value)
    this.fieldData.set(eventData.name, eventData.value);
  }

  allRequiredFieldsFilled(): boolean {
    return this.formDetail.every(field => {
      return !field.isRequired || (this.fieldData.get(field.name) !== null && this.fieldData.get(field.name) !== undefined && this.fieldData.get(field.name).toString() !== '');
    });
  }
}

export class FormDetail {
  constructor(placeHolder: string,name: string,type: string,value: any,labelName: string,showLabel: boolean=true, classcol:string='col-12',isRequired:boolean=false ){
    this.name = name;
    this.placeHolder = placeHolder;
    this.labelName = labelName;
    this.type = type;
    this.value = value;
    this.showLabel = showLabel;
    this.classcol = classcol;
    this.isRequired = isRequired;
  }
  placeHolder: string = '';
  name: string = '';
  type: string = 'string';
  value: any;
  showLabel: boolean = true;
  isRequired: boolean = false;
  labelName: string = ''
  classcol: string = ''
}
