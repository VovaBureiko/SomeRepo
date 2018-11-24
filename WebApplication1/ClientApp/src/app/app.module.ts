import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestingPageComponent } from './components/testing-page/testing-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SelectYourDestinyComponent } from './components/select-your-destiny/select-your-destiny.component';
import { HttpClientModule } from '@angular/common/http';
import { SpecializationService } from './services/specializationService';

@NgModule({
  declarations: [
    AppComponent,
    TestingPageComponent,
    HomePageComponent,
    SelectYourDestinyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [SpecializationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
