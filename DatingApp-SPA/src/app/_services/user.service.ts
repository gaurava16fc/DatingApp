import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiBaseUrl = '';

constructor(private http: HttpClient) {
  this.apiBaseUrl = environment.apiBaseUrl + 'users/';
 }

 getUsers(): Observable<User[]> {
 return this.http.get<User[]>(this.apiBaseUrl);
 }

 getUser(id: number): Observable<User> {
  return this.http.get<User>(this.apiBaseUrl + id);
  }

}
