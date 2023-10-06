import { Component, OnInit, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpProviderService } from "../services/http-provider.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  createContactForm: contactForm = new contactForm();

  @ViewChild("contactForm")
  contactForm!: NgForm;
  isSubmitted: boolean = false;
  constructor(private router: Router, private httpProvider: HttpProviderService, private toastr: ToastrService) { }

  ngOnInit(): void {  }

  CreateContact(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.createContact(this.createContactForm).subscribe(async data => {
        if (data != null && data.body != null) {
          if (data != null && data.body != null) {
            var resultData = data.body;
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
  Name: string = "";
  Surname: string = "";
  Email: string = "";
  Password: string = "";
  PhoneNumber: string = "";
  Birthdate: string = "";
  CategoryName: string = "";
}