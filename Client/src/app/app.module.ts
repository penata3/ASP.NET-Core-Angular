import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CreateCatComponent } from './create-cat/create-cat.component';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { HeaderComponent } from './header/header.component';
import { SecondaryAuthGuardService } from './services/secondary-auth-guard.service';
import { AllCatsComponent } from './all-cats/all-cats.component';
import { CatDetailsComponent } from './cat-details/cat-details.component';
import { CatUpdateComponent } from './cat-update/cat-update.component';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CreateCatComponent,
    HeaderComponent,
    AllCatsComponent,
    CatDetailsComponent,
    CatUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    AuthService,
    AuthGuardService,
    SecondaryAuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass:ErrorInterceptorService,
      multi:true
    }
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
