import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestingPageComponent } from './components/testing-page/testing-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SelectYourDestinyComponent } from './components/select-your-destiny/select-your-destiny.component';
import { HttpClientModule } from '@angular/common/http';
import { SpecializationService } from './services/specializationService';
import { TestingAreaComponent } from './components/testing-area/testing-area.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ConnectionService } from './services/testing.connection.service';
import { LogicService } from './services/logic';

@NgModule({
  declarations: [
    AppComponent,
    TestingPageComponent,
    HomePageComponent,
    SelectYourDestinyComponent,
    TestingAreaComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SpecializationService, ConnectionService, LogicService],
  bootstrap: [AppComponent]
})
export class AppModule { }
