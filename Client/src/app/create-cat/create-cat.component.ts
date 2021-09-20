import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-create-cat',
  templateUrl: './create-cat.component.html',
  styleUrls: ['./create-cat.component.css']
})
export class CreateCatComponent {
  catForm: FormGroup;
 
  constructor(
    private fb:FormBuilder,
    private catService: CatService
    ){
    this.catForm = this.fb.group({
      imageUrl: ['',Validators.required],
      description: ['']
    });
  }


  create(){
    if(this.catForm.invalid){return }
    this.catService.create(this.catForm.value).subscribe();
  }

  get imageUrl(){  
    return this.catForm.get('imageUrl');
  }
}
