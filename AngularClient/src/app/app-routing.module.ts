import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './helpers/auth.guard';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { SecretComponent } from './secret/secret.component';
import { ContactsNamesComponent } from './contacts-names/contacts-names.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { DeleteContactComponent } from './delete-contact/delete-contact.component';
import { ViewContactComponent } from './view-contact/view-contact.component';
import { UpdateContactComponent } from './update-contact/update-contact.component';

const routes: Routes = [
  {
    path: 'contactsNames',
    component: ContactsNamesComponent,
  },
  {
    path: '',
    component: SecretComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'login',
    component: LoginPageComponent,
  },
  {
    path: 'register',
    component: RegisterPageComponent,
  },
  {
    path: 'addContact',
    component: AddContactComponent
  },
  {
    path: 'removeContact',
    component: DeleteContactComponent
  },
  {
    path: 'viewContact/:contactId',
    component: ViewContactComponent
  },
  {
    path: 'updateContact/:contactId',
    component: UpdateContactComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
