import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../services/http-provider.service';

@Component({
  selector: 'app-update-contact',
  templateUrl: './update-contact.component.html',
  styleUrls: ['./update-contact.component.css']
})
export class UpdateContactComponent implements OnInit {
  updateContactForm: contactForm = new contactForm();

  @ViewChild("contactForm")
  contactForm!: NgForm;

  isSubmitted: boolean = false;
  contactId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.contactId = this.route.snapshot.params['contactId'];
    this.getContactDetails();
  }
  getContactDetails() {
    this.httpProvider.getContactDetails(this.contactId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.updateContactForm.Id = resultData.id;
          this.updateContactForm.Name = resultData.name;
          this.updateContactForm.Surname = resultData.surname;
          this.updateContactForm.Email = resultData.email;
          this.updateContactForm.Password = resultData.password;
          this.updateContactForm.PhoneNumber = resultData.phoneNumber;
          this.updateContactForm.Birthdate = resultData.birthdate;
          this.updateContactForm.CategoryName = resultData.categoryName;
        }
      }
    },
      (error: any) => { });
  }

  UpdateContact(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.updateContact(this.updateContactForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
          if (resultData != null && resultData.isSuccess) {
            if (resultData != null && resultData.isSuccess) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['/homeLoggedUser']);
              }, 500);
            }
          }
        }
      },
        async error => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['/homeLoggedUser']);
          }, 500);
        });
    }
  }
}

export class contactForm {
  Id: number = 0;
  Name: string = "";
  Surname: string = "";
  Email: string = "";
  Password: string = "";
  PhoneNumber: string = "";
  Birthdate: string = "";
  CategoryName: string = "";
}