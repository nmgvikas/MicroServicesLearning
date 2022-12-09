import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CustomersModule } from './app-customers/customer.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,CustomersModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
