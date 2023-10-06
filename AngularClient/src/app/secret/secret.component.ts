import { AuthenticationService } from './../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { HomeLoggedUserComponent } from '../home-logged-user/home-logged-user.component';
import { Observable } from 'rxjs';
import { AddContactComponent } from '../add-contact/add-contact.component';

@Component({
  selector: 'app-secret',
  templateUrl: './secret.component.html',
  styleUrls: ['./secret.component.css'],
})
export class SecretComponent implements OnInit {
  public contacts: Promise<any> = this.homeLoggedUser.getContacts();
  public createContact: void = this.homeLoggedUser.createContact();
  
  constructor(
    private authenticationService: AuthenticationService,
    private homeLoggedUser: HomeLoggedUserComponent,
  ) {}

  ngOnInit(): void {}

  logout(): void {
    this.authenticationService.logout();
  }
}