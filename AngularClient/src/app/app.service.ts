import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }

  rootURL = 'https://localhost:7237/api/';

  getContacts() {
    return this.http.get(this.rootURL + 'contacts/allContacts');
  }

  getContactsNames() : any {
    return this.http.get<any>(this.rootURL + 'contacts/names');
  }

  register() : any {
    return this.http.get<any>(this.rootURL + 'userauthentication/register');
  }

  login() : any {
    return this.http.get<any>(this.rootURL + 'userauthentication/login');
  }

  addContact(contact: any) {
    return this.http.post(this.rootURL + '/create', contact);
  }

}
