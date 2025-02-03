import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { MainComponent } from './main/main.component';
import { PatientComponent } from './Setup/patient/patient.component';
import { authGuard } from './guards/auth.guard';
import { RecommendationComponent } from './Setup/recommendation/recommendation.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    canActivate: [authGuard],
    children: [

  { path: 'patient', component: PatientComponent,canActivate: [authGuard] },
  { path: 'recommendation', component: RecommendationComponent, canActivate: [authGuard] }
      // Add more routes as needed
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  //{ path: 'main', component: MainComponent },

  //{ path: '', redirectTo: '/login', pathMatch: 'full' } // Default route
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
