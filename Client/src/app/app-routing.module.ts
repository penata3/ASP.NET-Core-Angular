import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllCatsComponent } from './all-cats/all-cats.component';
import { CatDetailsComponent } from './cat-details/cat-details.component';

import { CreateCatComponent } from './create-cat/create-cat.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AuthService } from './services/auth.service';
import { SecondaryAuthGuardService } from './services/secondary-auth-guard.service';

const routes: Routes = [ 
  { path: 'login',component: LoginComponent,canActivate: [SecondaryAuthGuardService] },

  { path: 'register', component: RegisterComponent,canActivate: [SecondaryAuthGuardService] },

  { path: 'create', component: CreateCatComponent,canActivate: [AuthGuardService] },

  { path:'all',component:AllCatsComponent,canActivate: [AuthGuardService] },

  { path: 'all/:id', component: CatDetailsComponent , canActivate: [AuthGuardService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
