import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  form: FormGroup;
  errorMessage: string| undefined = undefined;

  constructor(
    private fb:FormBuilder,
    private authService: AuthService,
    private router: Router) {
    this.form = this.fb.group({
      username: ['',[Validators.required,Validators.minLength(6)]],
      email: ['',[Validators.required,Validators.minLength(6),Validators.email]],
      password: ['',[Validators.required,Validators.minLength(6)]]
    })
   }


   get username(){
     return this.form.get('username');
   }

   get email(){
    return this.form.get('email');
  }

   get password(){
    return this.form.get('password');
  }

  register(){
    if(this.form.invalid){return; }

    //console.log(this.form.value);

    this.authService.register(this.form.value).subscribe(
      data => console.log(data)
    )

       
  }

}

