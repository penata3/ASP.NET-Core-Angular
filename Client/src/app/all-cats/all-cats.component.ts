import { Component } from '@angular/core';
import { Cat } from '../models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-all-cats',
  templateUrl: './all-cats.component.html',
  styleUrls: ['./all-cats.component.css']
})
export class AllCatsComponent  {

  cats: Cat[]|undefined;

  constructor(private catsService:CatService) {
    this.catsService.getAll().subscribe(cats => {
      this.cats = cats;
      console.log(this.cats)
    })
  }





}
