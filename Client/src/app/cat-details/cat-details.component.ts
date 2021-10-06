import { Component} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cat } from '../models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-cat-details',
  templateUrl: './cat-details.component.html',
  styleUrls: ['./cat-details.component.css']
})
export class CatDetailsComponent  {

  cat: Cat|undefined;
  constructor(private route:ActivatedRoute,private catsSerice: CatService) {
    route.params.subscribe(res => {
      this.catsSerice.getCatById(res['id']).subscribe(res => {
        this.cat = res;
        console.log(this.cat);
      })
    })
  }
}
