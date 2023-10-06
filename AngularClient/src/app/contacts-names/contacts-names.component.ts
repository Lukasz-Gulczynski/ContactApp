import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AppService } from '../app.service';

@Component({
  selector: 'app-contacts-names',
  templateUrl: './contacts-names.component.html',
  styleUrls: ['./contacts-names.component.css']
})
export class ContactsNamesComponent implements OnInit, OnDestroy {

  constructor(private appService: AppService) {}

  contactsNames: any[] = [];
  test: any;
  destroy$: Subject<boolean> = new Subject<boolean>();
  
  getContactsNames() {
    this.appService.getContactsNames().subscribe((contactsNames: any[]) => {
        this.contactsNames = contactsNames;
    });
  }

  ngOnInit() {
    this.getContactsNames();
    
    this.test = this.contactsNames.length
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }
}
