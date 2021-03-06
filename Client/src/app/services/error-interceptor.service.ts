import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService implements HttpInterceptor{

  constructor(private toastrService:ToastrService){ }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    return next.handle(req).pipe(
      retry(1),
      catchError(err => {
        let message = '';

        if(err.status == '401'){
          message = 'You are not logged in';
        }
        else if(err.status == '400'){
          message = 'Bad request'
        }
        else if (err.status ='404'){
          message='Not found';
        }
        else {
          message='Uexpected error!'
        }       
        this.toastrService.error(message);
        return throwError(err);
      })
    )
  }


}
