import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable,throwError} from "rxjs";
import {map,catchError} from 'rxjs/operators';
import { ICustomer } from "./ICustomer";

@Injectable()
export class CustomerDataService {
    customerApiUrl = "http://172.17.0.5:7071/api/customers";
    httpSocket : HttpClient;
    constructor(httpSocket:HttpClient){
        this.httpSocket = httpSocket;
    }

    getAllCustomers(): Observable<ICustomer[]> {
        return this.httpSocket.get<ICustomer[]>(this.customerApiUrl)
        .pipe(
            catchError(this.handleError)
        )
    }
    searchCustomers(searchString : string) : Observable<ICustomer[]> {
        return this.httpSocket.get<ICustomer[]>(this.customerApiUrl+"/searchByName/"+searchString)
        .pipe(
            catchError(this.handleError)
        )
    }
    handleError(error:any){
        return throwError( () => new Error("Error from API"));
    }
}