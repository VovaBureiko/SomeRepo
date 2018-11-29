import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EndTestRoutingModule } from './end-test-routing.module';
import { EndTestComponent } from './end-test/end-test.component';

@NgModule({
  declarations: [EndTestComponent],
  imports: [
    CommonModule,
    EndTestRoutingModule
  ]
})
export class EndTestModule { }
