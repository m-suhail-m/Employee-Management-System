import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDepartmentComponent } from './Departments/add-department/add-department.component';
import { AddEmployeeComponent } from './Employees/add-employee/add-employee.component';
import { AddPositionComponent } from './Positions/add-position/add-position.component';

const routes: Routes = [
  {path:'add-employee', component:AddEmployeeComponent},
  {path:'add-position', component:AddPositionComponent},
  {path:'add-department', component:AddDepartmentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
