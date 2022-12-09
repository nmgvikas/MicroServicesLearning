import { Component, OnInit } from "@angular/core"; 
import { CustomerDataService } from "./customers.data.service";
import { ICustomer } from "./ICustomer";
import * as signalR from "@aspnet/signalr";

@Component({
    selector: "app-customers",
    templateUrl:"./customers.component.html"
})
class CustomersComponent implements OnInit{
   
    lstCustomers : ICustomer[] = [];
    _dataService : CustomerDataService;
    notificationData : any;
    //c'tor
    constructor (dataService : CustomerDataService){
                this._dataService = dataService;
    }
      title : string  = "Old Title"


      searchCustomers(event:any) {
        if(event.target.value.length > 0){
            console.log(event.target.value);
            this._dataService.searchCustomers(event.target.value as string)
            .subscribe((custs : ICustomer[]) => {
                this.lstCustomers = custs;
            })
        }
        else {
            //call getAllCustomers
            this._dataService.getAllCustomers()
            .subscribe((custs:ICustomer[]) => {
                 this.lstCustomers = custs;
            })
        }
        
      }
     ngOnInit(): void {
       this.title = "Customers Component"

       //Get the list of customers
       this._dataService.getAllCustomers()
       .subscribe((custs:ICustomer[]) => {
            this.lstCustomers = custs;
       })

       //connect to signalR Hub
       var connection = new signalR.HubConnectionBuilder()
       .configureLogging(signalR.LogLevel.Debug)
       .withUrl("https://localhost:7134/customerHub",{
        skipNegotiation:true, transport: signalR.HttpTransportType.WebSockets
       }).build();
       
       connection.start().then(function(){
        console.log("SignalR connected")
        //Subscribe
        connection.invoke("SubscribeToNewCustomers","sriniiyer","19-Dec-2022")
        .catch(function(err){
            return console.log(err.toString());
        })
       })
       //handle the notification
      connection.on("NewCustomerNotification", (message)=> {
        this.notificationData += "New Customer Norification " + message + "<br\>";
        //document.getElementById("myContent").innerHTML = this.notificationData;
      })

    }
}

export default CustomersComponent;