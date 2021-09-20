import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-cat',
  templateUrl: './create-cat.component.html',
  styleUrls: ['./create-cat.component.css']
})
export class CreateCatComponent {
  catForm: FormGroup;
 
  constructor(private fb:FormBuilder){
    this.catForm = this.fb.group({
      imageUrl: ['',Validators.required],
      description: ['']
    });
  }


  create(){

  }

  get imageUrl(){
    return this.catForm.get('imageUrl');
  }
}
