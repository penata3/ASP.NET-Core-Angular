import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateCatComponent } from './create-cat/create-cat.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { SecondaryAuthGuardService } from './services/secondary-auth-guard.service';

const routes: Routes = [ 
  {
    path: 'login',
    component: LoginComponent,canActivate: [SecondaryAuthGuardService]
  },
  {
    path: 'register',
    component: RegisterComponent,canActivate: [SecondaryAuthGuardService]
  },
  { path: 'create', component: CreateCatComponent,canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
