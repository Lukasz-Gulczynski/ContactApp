import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationClient {
  constructor(private http: HttpClient) {}

  rootURL = 'https://localhost:7237/api';

  public login(username: string, password: string): Observable<string> {
    return this.http.post(
        this.rootURL + '/userauthentication/login',
      {
        username: username,
        password: password,
      },
      { responseType: 'text' }
    );
  }

  public register(
    firstName: string,
    username: string,
    email: string,
    password: string
  ): Observable<string> {
    return this.http.post(
      this.rootURL + '/userauthentication/register',
      {
        firstName: firstName,
        username: username,
        email: email,
        password: password,
      },
      { responseType: 'text' }
    );
  }
}