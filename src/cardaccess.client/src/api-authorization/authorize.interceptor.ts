import { Inject, Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeInterceptor implements HttpInterceptor {
  loginUrl: string;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.loginUrl = `${baseUrl}Identity/Account/Login`;
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse) {
          if (error.status === 401 || error.url?.startsWith(this.loginUrl)) {
            // Redirect to login page if the user is not authenticated
            window.location.href = `${this.loginUrl}?ReturnUrl=${encodeURIComponent(window.location.pathname)}`;
          }
        }
        return throwError(() => error);
      }),
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          if (event.status === 401 || event.url?.startsWith(this.loginUrl)) {
            // Redirect to login page for non-error responses that need redirection
            window.location.href = `${this.loginUrl}?ReturnUrl=${encodeURIComponent(window.location.pathname)}`;
          }
        }
        return event;
      })
    );
  }
}
