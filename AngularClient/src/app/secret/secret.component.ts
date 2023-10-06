import { AuthenticationService } from './../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactsClient } from '../clients/contacts.client';

@Component({
  selector: 'app-secret',
  templateUrl: './secret.component.html',
  styleUrls: ['./secret.component.css'],
})
export class SecretComponent implements OnInit {
  public contacts: Observable<any> = this.contactsClient.getAllContacts();
  
  constructor(
    private authenticationService: AuthenticationService,
    private contactsClient: ContactsClient
  ) {}

  ngOnInit(): void {}

  logout(): void {
    this.authenticationService.logout();
  }
}