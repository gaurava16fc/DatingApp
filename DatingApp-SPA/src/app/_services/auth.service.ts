import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBaseUrl = '';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

constructor(private http: HttpClient) {
  this.apiBaseUrl = environment.apiBaseUrl + 'auth/';
 }

login(model: any) {
  return this.http.post(this.apiBaseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
}

register(model: any) {
  return this.http.post(this.apiBaseUrl + 'register', model);
}

loggedIn() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
}
}
