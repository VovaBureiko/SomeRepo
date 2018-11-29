import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EndTestComponent } from './end-test/end-test.component';

const routes: Routes = [
  {path: 'endtest/:userId', component: EndTestComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EndTestRoutingModule { }
