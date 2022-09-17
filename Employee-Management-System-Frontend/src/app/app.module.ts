import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddEmployeeComponent } from './Employees/add-employee/add-employee.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPositionComponent } from './Positions/add-position/add-position.component';
import { AddDepartmentComponent } from './Departments/add-department/add-department.component';
import { ViewPositionsComponent } from './Positions/view-positions/view-positions.component';
import { ViewDepartmentsComponent } from './Departments/view-departments/view-departments.component';
import { ViewEmployeesComponent } from './Employees/view-employees/view-employees.component';
import { UpdateEmployeeComponent } from './Employees/update-employee/update-employee.component';
import { DatePipe } from '@angular/common';
import { HierarchyComponent } from './hierarchy/hierarchy.component';


@NgModule({
  declarations: [
    AppComponent,
    AddEmployeeComponent,
    AddPositionComponent,
    AddDepartmentComponent,
    ViewPositionsComponent,
    ViewDepartmentsComponent,
    ViewEmployeesComponent,
    UpdateEmployeeComponent,
    HierarchyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
