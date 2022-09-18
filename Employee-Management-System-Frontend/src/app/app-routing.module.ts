import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDepartmentComponent } from './Departments/add-department/add-department.component';
import { UpdateDepartmentComponent } from './Departments/update-department/update-department.component';
import { ViewDepartmentsComponent } from './Departments/view-departments/view-departments.component';
import { AddEmployeeComponent } from './Employees/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './Employees/update-employee/update-employee.component';
import { ViewEmployeesComponent } from './Employees/view-employees/view-employees.component';
import { HierarchyComponent } from './hierarchy/hierarchy.component';
import { AddPositionComponent } from './Positions/add-position/add-position.component';
import { UpdatePositionComponent } from './Positions/update-position/update-position.component';
import { ViewPositionsComponent } from './Positions/view-positions/view-positions.component';

const routes: Routes = [
  {path:'add-employee', component:AddEmployeeComponent},
  {path:'add-position', component:AddPositionComponent},
  {path:'add-department', component:AddDepartmentComponent},
  {path:'view-employees', component:ViewEmployeesComponent},
  {path:'view-positions', component:ViewPositionsComponent},
  {path:'view-departments', component:ViewDepartmentsComponent},
  {path:'update-employee/:id', component:UpdateEmployeeComponent},
  {path:'update-position/:id', component:UpdatePositionComponent},
  {path:'update-department/:id', component:UpdateDepartmentComponent},
  {path:'view-hierarchy', component:HierarchyComponent},
  {path:'', redirectTo:'view-hierarchy', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
