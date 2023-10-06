import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

var apiUrl = "https://localhost:7237/api/";

var httpLink = {
  getContacts: apiUrl + "contacts/allContacts",
  getContactsNames: apiUrl + "contacts/names",
  deleteContact: apiUrl + "contacts/delete",
  getContactDetail: apiUrl + "contacts/details",
  updateContact: apiUrl + "contacts/update",
  createContact: apiUrl + "contacts/create",
  register: apiUrl + "userauthentication/register",
  login: apiUrl + "userauthentication/login"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {
  constructor(private webApiService: WebApiService) { }

  public getContacts(): Observable<any> {
    return this.webApiService.get(httpLink.getContacts);
  }
  public getContactsNames(): Observable<any> {
    return this.webApiService.get(httpLink.getContactsNames);
  }
  public deleteContact(model: any): Observable<any> {
    return this.webApiService.post(httpLink.deleteContact + '?contactId=' + model, "");
  }
  public getContactDetails(model: any): Observable<any> {
    return this.webApiService.get(httpLink.getContactDetail + '?contactId=' + model);
  }
  public updateContact(model: any): Observable<any> {
    return this.webApiService.post(httpLink.updateContact + '?contactId=', model);
  }
  public createContact(model: any): Observable<any> {
    return this.webApiService.post(httpLink.createContact, model);
  }  
  public register(model: any): Observable<any> {
    return this.webApiService.post(httpLink.register, model);
  }  
  public login(model: any): Observable<any> {
    return this.webApiService.post(httpLink.login, model);
  }    
}                          