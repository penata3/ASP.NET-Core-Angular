import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  {

  form: FormGroup;

  constructor(private fb:FormBuilder) { 
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

  login(){
    console.log(this.form.value);
  }


}
