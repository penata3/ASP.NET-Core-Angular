import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms'
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  form: FormGroup;
  errorMessage: string| undefined = undefined;

  constructor(
    private fb:FormBuilder,
    private authService: AuthService,
    private router: Router) { 
    this.form = this.fb.group({
      username: ['',[Validators.required,Validators.minLength(6)]],
      password: ['',[Validators.required,Validators.minLength(6)]]
    })
  }


  get username() {
    return this.form.get('username');
  }

  get password() {
    return this.form.get('password');
  }

  login():void{
    if(this.form.invalid){return }

    this.authService.login(this.form.value).subscribe(
      {
        next: (response) => {
          this.authService.setToken(response.token),
          this.router.navigate(['/'])
        },
        error: (error) => {
          this.errorMessage = error.error;
        }
      }
    
    )
    this.form.reset();     
  }


}
