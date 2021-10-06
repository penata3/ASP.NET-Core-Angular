import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cat } from '../models/cat';

@Injectable({
  providedIn: 'root'
})
export class CatService {


  private catsUrl = environment.apiUrl + 'cats'

  constructor(private http:HttpClient) { }

  create(data:any): Observable<Cat> {
    return this.http.post<Cat>(this.catsUrl, data)
  }

  getAll():Observable<Cat[]> { 
    return this.http.get<Cat[]>(this.catsUrl);    
  }

  getCatById(id:string):Observable<Cat> {
    return this.http.get<Cat>(`${this.catsUrl}/${id}`);
  }

  deleteCat(id:number):Observable<any> {  
    return this.http.delete(`${this.catsUrl}/${id}`);
  }

}
