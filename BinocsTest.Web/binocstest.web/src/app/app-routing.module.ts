import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { ListsComponent } from './lists/lists.component';

const routes: Routes = [
  {
  
    path: 'list/:id', component: ListComponent, pathMatch: "full"
  },
  {
  
    path: '', component: ListsComponent, pathMatch: "full"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
