import { NgModule } from "@angular/core"
import {CommonModule} from "@angular/common";
import CustomersComponent from "./customers.component";
import { CustomerDataService } from "./customers.data.service";
import {HttpClientModule} from "@angular/common/http"

@NgModule({
    declarations: [CustomersComponent],
    providers:[CustomerDataService],
    imports:[CommonModule,HttpClientModule],
    exports:[CustomersComponent]

})
export class CustomersModule{}

