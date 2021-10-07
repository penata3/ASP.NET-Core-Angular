import { Component} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Cat } from '../models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-cat-update',
  templateUrl: './cat-update.component.html',
  styleUrls: ['./cat-update.component.css']
})
export class CatUpdateComponent  {

  catToUpdate: Cat|undefined;
  catId: string | undefined;
  updateCatForm: FormGroup;

  constructor(private route:ActivatedRoute, private catsService:CatService, private fb:FormBuilder, private router: Router) { 

    this.updateCatForm = this.fb.group( {
      'id': [''],
      'description': ['']
    });

    this.route.params.subscribe(res => {
      this.catId = res['id'];
      this.catsService.getCatById(res['id']).subscribe(result => {
        this.catToUpdate = result;
        this.updateCatForm = this.fb.group( {
          'id': [`${this.catToUpdate.id}`],
          'description': [`${this.catToUpdate.description}`]
        });
      })    
    })

  }

 updateCat(){
   this.catsService.updateCat(this.updateCatForm.value).subscribe(res => {
    this.router.navigate(['/all', this.catId])
   });

 }


  

 


}
