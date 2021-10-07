import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Cat } from '../models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-all-cats',
  templateUrl: './all-cats.component.html',
  styleUrls: ['./all-cats.component.css']
})
export class AllCatsComponent {

  cats: Cat[]|undefined;

  constructor(private catsService:CatService,
    private router: Router) { 
      this.fetchCats();
  }

  fetchCats():void {
    this.catsService.getAll().subscribe(cats => {
      this.cats = cats;
    })
  }

 delete(catId:number){
    this.catsService.deleteCat(catId).subscribe(res => {
      this.fetchCats();
    });        
 }
}
