import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import '@angular/localize/init';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule  } from '@angular/forms';
import { BalanceComponent } from './balance/balance.component';
import { MainComponent } from './main/main.component';
import { AreaComponent } from './Setup/area/area.component';
import { IndustryComponent } from './Setup/industry/industry.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CompanyComponent } from './MainForm/company/company.component';
import { AddCompanyComponent } from './MainForm/company/add-company/add-company.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PaginationComponent } from './pagination/pagination.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductComponent } from './Setup/product/product.component';
import { ModalComponent } from './Common/modal/modal.component';
import { InputComponent } from './Common/input/input.component';
import { TextareaComponent } from './Common/textarea/textarea.component';
import { TableComponent } from './Common/table/table.component';
import { QuotationComponent } from './MainForm/quotation/quotation.component';
import { AddQuotationComponent } from './MainForm/quotation/add-quotation/add-quotation.component';
import { DropdownComponent } from './Common/dropdown/dropdown.component';
import { TextselectDirective } from './textselect.directive';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    BalanceComponent,
    MainComponent,
    AreaComponent,
    IndustryComponent,
    DashboardComponent,
    CompanyComponent,
    AddCompanyComponent,
    PaginationComponent,
    ProductComponent,
    ModalComponent,
    InputComponent,
    TextareaComponent,
    TableComponent,
    QuotationComponent,
    AddQuotationComponent,
    DropdownComponent,
    TextselectDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule ,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
