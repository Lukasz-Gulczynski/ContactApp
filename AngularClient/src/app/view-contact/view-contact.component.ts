import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { HttpProviderService } from "../services/http-provider.service";
import { WebApiService } from "../services/web-api.service";

@Component({
  selector: 'app-view-contact',
  templateUrl: './view-contact.component.html',
  styleUrls: ['./view-contact.component.css']
})
export class ViewContactComponent implements OnInit {

  contactId: any;
  contactDetail : any= [];
   
  constructor(public webApiService: WebApiService, private route: ActivatedRoute, private httpProvider : HttpProviderService) { }
  
  ngOnInit(): void {
    this.contactId = this.route.snapshot.params['contactId'];      
    this.getContactDetails();
  }

  getContactDetails() {       
    this.httpProvider.getContactDetails(this.contactId).subscribe((data : any) => {      
      if (data != null && data.body != null) {
        var resultData = data.body;
        if (resultData) {
          this.contactDetail = resultData;
        }
      }
    },
    (error :any)=> { }); 
  }

}