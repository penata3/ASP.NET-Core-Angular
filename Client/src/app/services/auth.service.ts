import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';




@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loginUrl = environment.apiUrl + `identity/login`;
  registerUrl = environment.apiUrl + `identity/register`;

  constructor(private http: HttpClient) { }


  register(data: any): Observable<any> {
    return this.http.post(this.registerUrl, data);
  }

  login(data: any): Observable<any> {
    return this.http.post(this.loginUrl, data);
  }

  setToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    if (this.getToken()) {
      return true;
    }
    return false;
  }
}
