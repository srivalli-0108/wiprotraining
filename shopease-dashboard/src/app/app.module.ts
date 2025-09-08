import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // ✅ Import FormsModule

import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ProductDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule // ✅ Include here
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
