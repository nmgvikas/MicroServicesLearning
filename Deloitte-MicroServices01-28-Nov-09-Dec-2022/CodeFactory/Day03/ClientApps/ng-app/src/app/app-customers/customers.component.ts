import { Component, OnInit } from "@angular/core"; 

@Component({
    selector: "app-customers",
    templateUrl:"./customers.component.html"
})
class CustomersComponent implements OnInit{
   

    //c'tor
    public CustomerComponent(){

    }
     public title : string  = "Old Title"

     ngOnInit(): void {
       this.title = "Customers Component"
    }
}

export default CustomersComponent;