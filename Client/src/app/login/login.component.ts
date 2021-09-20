import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms'
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  form: FormGroup;

  constructor(
    private fb:FormBuilder,
    private authService: AuthService) { 
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
      response => this.authService.setToken(response.token),
     error => {
       console.log(error.error.text);
     }
    )

    this.form.reset();
     
  }


}
