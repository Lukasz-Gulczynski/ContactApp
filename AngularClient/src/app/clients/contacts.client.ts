import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ContactsClient {
  constructor(private http: HttpClient) {}

  rootURL = 'https://localhost:7237/api/';

  getAllContacts(): Observable<any> {
    return this.http.get(this.rootURL + 'contacts/allContacts');
  }
}