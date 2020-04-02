import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBaseUrl = '';

constructor(private http: HttpClient) {
  this.apiBaseUrl = environment.apiBaseUrl;
 }
login(model: any) {
  return this.http.post(this.apiBaseUrl + 'auth/login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
        }
      })
    );
}

}
