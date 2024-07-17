import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormDetail, ModalComponent } from 'src/app/Common/modal/modal.component';
import {SetupService} from '../../services/setup.service'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  showModel:boolean=false;
  @ViewChild('productModal') productModal !: ModalComponent;
  formDetail:FormDetail[] = [];
  modalFormTitle:string="Add Product"
  hasPrevPage:boolean=false;
  hasNextPage:boolean=false;
  isUpdate:boolean=false;
  updateId:string='';
  totalCount:number=0;
  totalPages:number = 10;
  pageIndex:number = 1;
  searchValue:string = '';
  productColumns: TableColumn[] = [
    {
      key: 'name', title: 'Name', width: '40%',
      buttons: []
    },
    {
      key: 'salePrice', title: 'Sale Price', width: '20%',
      buttons: []
    },
    {
      key: 'retailPrice', title: 'Retail Price', width: '20%',
      buttons: []
    },
    { key: 'actions', title: 'Actions',buttons:['edit','del'], isActionColumn: true,width:'15%' }
  ];
  products = [
    
  ];
  constructor(private setupService:SetupService){
    this.GenerateFormDetail();
  }

  fetchProducts() {
    this.setupService.GetAll("Product", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.products = response.items.map((prod: any)=>({
          id: prod.id,
          name: prod.name,
          salePrice: prod.salePrice,
          retailPrice: prod.retailPrice,
          description: prod.description,
          isActive: prod.isActive
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

  ngOnInit(){
    this.fetchProducts();
  }

  GenerateFormDetail(){
    this.formDetail = [
      new FormDetail('Name','name','string','','Name',true,'col-12',true),
      new FormDetail('Retail Price','retailPrice','number','','Retail Price',true,'col-6',true),
      new FormDetail('Sale Price','salePrice','number','','Sale Price',true,'col-6',true),
      new FormDetail('Description','description','textarea','','Description',true,'col-12'),
    ]
  }
  fieldDataEmit(data:Map<string,any>){
    const result: {[key: string]: any} = {};
    data.forEach((value, key) => {
      result[key] = value;
    });
    result['isActive'] = true;
    if(this.isUpdate){
      result['id'] = this.updateId;
      this.updateProduct(result)
    }
    else{
      this.addProduct(result);
    }
    
  }
  search() {
    this.setupService.Search("Product",this.searchValue, this.pageIndex, this.totalPages).subscribe({
      next: (response) => {
        this.totalCount = response.totalRecord;
        this.hasPrevPage = response.hasPrevPage;
        this.hasNextPage = response.hasNextPage;
        this.products = response.items.map((prod: any)=>({
          id: prod.id,
          name: prod.name,
          salePrice: prod.salePrice,
          retailPrice: prod.retailPrice,
          description: prod.description,
          isActive: prod.isActive
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
  AddProduct(){
    this.productModal.show()
  }
  closeModelEvent(isClose:boolean){
    this.GenerateFormDetail();
    this.productModal.hide()
  }
  OnPageChangeEmit(pageIndex:number){
    this.pageIndex = pageIndex;
    this.fetchProducts();
  }
  OnEditEmit(item:any){
    this.isUpdate=true;
    this.updateId = item.id;
    for(var data of this.formDetail){
      data.value = item[data.name].toString();
    }
    this.productModal.show()
  }
  OnDeleteEmit(item:any){
    this.deleteProduct(item.id);
  }
  addProduct(data:Product) {
    this.setupService.Create("Product",data).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.isUpdate=false;
        this.updateId = '';
        this.closeModelEvent(true);
        this.GenerateFormDetail();
        this.fetchProducts();
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error.error.message,
          icon: 'error'
        })
        // Handle error
      }
    });
  }

  updateProduct(data:Product) {
    this.setupService.Update("Product",data).subscribe({
      next: (response) => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.isUpdate=false;
        this.updateId = '';
        this.closeModelEvent(true);
        this.GenerateFormDetail();
        this.fetchProducts();
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error.error.message,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
  deleteProduct(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this record!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.setupService.Delete("Product",id).subscribe({
          next: () => {
            this.fetchProducts();
        Swal.fire(
          'Deleted!',
          'Your record has been deleted.',
          'success'
        );
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
        
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your record is safe :)',
          'error'
        );
      }
    });
    
  }
}
