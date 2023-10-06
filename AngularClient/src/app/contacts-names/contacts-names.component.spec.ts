import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactsNamesComponent } from './contacts-names.component';

describe('ContactsNamesComponent', () => {
  let component: ContactsNamesComponent;
  let fixture: ComponentFixture<ContactsNamesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContactsNamesComponent]
    });
    fixture = TestBed.createComponent(ContactsNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
