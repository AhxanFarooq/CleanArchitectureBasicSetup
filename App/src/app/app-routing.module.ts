import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { BalanceComponent } from './balance/balance.component';
import { MainComponent } from './main/main.component';
import { AreaComponent } from './Setup/area/area.component';
import { IndustryComponent } from './Setup/industry/industry.component';
import { authGuard } from './guards/auth.guard';
import { CompanyComponent } from './MainForm/company/company.component';
import { AddCompanyComponent } from './MainForm/company/add-company/add-company.component';
import { ProductComponent } from './Setup/product/product.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    canActivate: [authGuard],
    children: [
      
  { path: 'area', component: AreaComponent,canActivate: [authGuard] },
  { path: 'industry', component: IndustryComponent, canActivate: [authGuard] },
  { path: 'product', component: ProductComponent, canActivate: [authGuard] },
  { path: 'contact', component: CompanyComponent, canActivate: [authGuard] },
  { path: 'addContact', component: AddCompanyComponent, canActivate: [authGuard] },
      // Add more routes as needed
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'balance', component: BalanceComponent },
  //{ path: 'main', component: MainComponent },
  
  //{ path: '', redirectTo: '/login', pathMatch: 'full' } // Default route
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
