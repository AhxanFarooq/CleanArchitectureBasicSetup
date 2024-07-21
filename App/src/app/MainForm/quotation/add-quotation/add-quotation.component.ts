import { Component } from '@angular/core';
import { Contact } from '../../company/company.component';
import { CompanyService } from 'src/app/services/company.service';
import Swal from 'sweetalert2';
import { SetupService } from 'src/app/services/setup.service';
import { QuotationService } from 'src/app/services/quotation.service';
import { Router, ActivatedRoute } from '@angular/router';
import moment from 'moment';

@Component({
  selector: 'app-add-quotation',
  templateUrl: './add-quotation.component.html',
  styleUrls: ['./add-quotation.component.css']
})
export class AddQuotationComponent {

  constructor(private companyService:CompanyService, private setupService:SetupService,
     private router: Router, private quotationService: QuotationService, private route: ActivatedRoute
  ){

    this.route.queryParams.subscribe(params => {
      this.editCustomerId = params['data'];
      if (this.editCustomerId != undefined) {
        this.isEdit = true;
        this.getQuotationById()
      }

    });

    this.fetchContacts();
    this.fetchProducts();
    this.addQuotationItemField();
    if(!this.isEdit){
      this.GetAutoCode();
      this.newQuotation.date = moment(new Date()).format('YYYY-MM-DD'); 
      this.newQuotation.dueDate = moment(new Date()).format('YYYY-MM-DD'); 
    }
  }

  //Quotation field
  
  newQuotation: Quotation = new Quotation();
  editCustomerId: string = '';
  isEdit: boolean = false;

  //Quotation field

  pageIndex:number=0;
  totalPages:number=0;
  labelContactDropdown:string='Contact';
  labelProductDropdown:string='Product';
  items:Array<{name: string, id: string}> = [];
  productItems:Array<{name: string, id: string}> = [];

  fetchContacts() {
    this.companyService.GetAll(this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.items = response.items.map((contact: Contact)=>({
          id: contact.id,
          name: contact.companyTitle
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
  fetchProducts() {
    this.setupService.GetAll("Product", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.productItems = response.items.map((prod: any)=>({
          id: prod.id,
          name: prod.name
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
  getQuotationById() {
    this.quotationService.GetById(this.editCustomerId).subscribe({
      next: (response) => {
        this.newQuotation = response;
        this.newQuotation.date = moment(this.newQuotation.date).format('YYYY-MM-DD') ;
        this.newQuotation.dueDate = moment(this.newQuotation.dueDate).format('YYYY-MM-DD') ;
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
  GetAutoCode() {
    this.quotationService.GetAutoCode().subscribe({
      next: (response) => {
        
        this.newQuotation.code = response.code;
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
  SaveChanges() {
    this.quotationService.Create(this.newQuotation).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.newQuotation = new Quotation();
        this.GetAutoCode();
        this.newQuotation.contactId = '00000000-0000-0000-0000-000000000000';
        this.newQuotation.date = moment(new Date()).format('YYYY-MM-DD'); 
      this.newQuotation.dueDate = moment(new Date()).format('YYYY-MM-DD');
        this.addQuotationItemField()
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
  NavigateToList() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover.!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, cancel it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Navigate!',
          'Navigate to list page.',
          'success'
        )
        this.router.navigate(['/quotation']);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your page is safe :)',
          'error'
        )
      }
    });
    
  }
  UpdateChanges() {
    this.quotationService.Update(this.newQuotation).subscribe({
      next: () => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.router.navigate(['/quotation']);
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
  addQuotationItemField() {
    this.newQuotation.quotationItemModels.push(new QuotationItems());
  }
  removeQuotationItemField(index: number) {
    this.newQuotation.quotationItemModels.splice(index, 1);
    this.calculateTotal();
  }

  onDropdownChange(selectedValue: any) {
    this.newQuotation.contactId = selectedValue;
  }
  onProductDropdownChange(index:number, selectedValue: any) {
    this.newQuotation.quotationItemModels[index].productId = selectedValue
  }
  onDiscountSignChange(index:number) {
    var data = this.newQuotation.quotationItemModels[index];
    if(data.discountSign === 'F' )
      data.discountSign = '%'
    else{
      data.discountSign = 'F'
    }
    this.calculateLineTotal(index, 'discount', data.discount)
  }

  calculateLineTotal(index:number, fieldName:string,value:number){
    var data = this.newQuotation.quotationItemModels[index];
    var total = 0;
    var disValue = data.discount;
    if(FieldName.UnitPrice.toLowerCase() == fieldName.toLowerCase()){
      total = (value * data.quantity);
    }
    else if(FieldName.Quantity.toLowerCase() == fieldName.toLowerCase()){

      total = (data.unitPrice * value);
    }
    else if(FieldName.Discount.toLowerCase() == fieldName.toLowerCase())
    {
      total = (data.unitPrice * data.quantity);
      disValue = value
      
    }
    if(data.discountSign === 'F'){
      total = total- disValue;
    }
    else{
      total = total - ((total * disValue)/100)
    }
    data.lineTotal = total;
    this.calculateTotal();
  }
  onOverallDiscChangeSign(){
    if(this.newQuotation.overallDiscSign === '%'){
      this.newQuotation.overallDiscSign = 'F'
    }
    else{
      this.newQuotation.overallDiscSign = '%'
    }
    this.calculateTotal()
  }
  onChangeSign(){
    if(this.newQuotation.taxSign === '%'){
      this.newQuotation.taxSign = 'F'
    }
    else{
      this.newQuotation.taxSign = '%'
    }
    this.calculateTotal()
  }
  onOverAllChanging(){
    this.calculateTotal();
  }
  calculateTotal(fieldName:string = 'all'){
    let total = this.newQuotation.quotationItemModels.reduce((accumulator, currentItem) => {
      return accumulator + currentItem.lineTotal;
    }, 0);
    this.newQuotation.totalAmount = total;
      //calculate discount
      if(this.newQuotation.overallDiscSign === 'F'){
        total =  total - this.newQuotation.discount;
      }
      else{
        total = total - ((this.newQuotation.discount * total)/100);
      }

      //calculate tax 
      if(this.newQuotation.taxSign === 'F'){
        total =  total + this.newQuotation.saleTax;
      }
      else{
        total = total + ((this.newQuotation.saleTax * total)/100);
      }
      
      this.newQuotation.netAmount = total;
  }
}
enum FieldName{
  UnitPrice = 'unitPrice',
  Quantity = 'quantity',
  Discount = 'discount',
  ALL = 'all'
}

export class Quotation{
    id:string='00000000-0000-0000-0000-000000000000' 
    code: string='';
    contactId: string = '00000000-0000-0000-0000-000000000000';
    date: string='';
    dueDate: string='';
    totalAmount: number = 0;
    discount: number = 0;
    saleTax: number = 0;
    netAmount: number = 0;
    termAndCondition: string = "";
    quotationItemModels: QuotationItems[] = [];
    taxSign:string='F';
    overallDiscSign:string='F';
}

export class QuotationItems{
  id: string = '00000000-0000-0000-0000-000000000000';
  productId: string = '00000000-0000-0000-0000-000000000000';
  quotationId: string = '00000000-0000-0000-0000-000000000000';
  unitPrice: number = 0;
  quantity: number = 0;
  discount: number = 0;
  lineTotal: number = 0;
  discountSign:string='F';
}
