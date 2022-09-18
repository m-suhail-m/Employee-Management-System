import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/Interfaces/employee';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-view-employees',
  templateUrl: './view-employees.component.html',
  styleUrls: ['./view-employees.component.css']
})
export class ViewEmployeesComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService: HttpService, private router:ActivatedRoute) { }

  employees:Employee[] =[]

  GetAllEmployees():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllEmployees')
  }

  Delete(id:number){
    if(confirm("Are you sure you want to delete this employee?")){
      this.httpClient.delete(this.httpService.httpLink + 'Employee/DeleteEmployee/' + id).subscribe(()=>{
        alert("Employee deleted successfully")
        location.reload()
      },()=>{
        alert("The employee was unable to be deleted")
      })
    }
  }

  Search(query:string){
    this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/SearchEmployeesByQuery/' + query).subscribe(res=>{
      this.employees = res
    },()=>{
      alert("No results found")
    })
  }
  ngOnInit(): void {
    this.GetAllEmployees().subscribe(res=>{
      this.employees = res
      
    },()=>{
      this.httpService.FetchError()
    })
  }

  SortByEmpNumber(){
    this.employees.sort(function(a, b){
      let x = a.employeeNumber
      let y = b.employeeNumber
      if (x < y) {return -1;}
      if (x > y) {return 1;}
      return 0;
    })
  }
  SortByName(){
    this.employees.sort(function(a, b){
      let x = a.name.toLowerCase();
      let y = b.name.toLowerCase();
      if (x < y) {return -1;}
      if (x > y) {return 1;}
      return 0;
    })
  }
  SortBySurname(){
    this.employees.sort(function(a, b){
      let x = a.surname.toLowerCase();
      let y = b.surname.toLowerCase();
      if (x < y) {return -1;}
      if (x > y) {return 1;}
      return 0;
    })
  }
  SortByDateOfBirth(){
    this.employees.sort(function(a, b){
      let x = a.birthDate
      let y = b.birthDate
      if (x < y) {return -1;}
      if (x > y) {return 1;}
      return 0;
    })
  }  
  SortBySalary(){
    this.employees.sort(function(a, b){return b.salary - a.salary})
  }
  SortByPosition(){
    this.employees.sort(function(a, b){
      let x = a.position.positionName.toLowerCase();
      let y = b.position.positionName.toLowerCase();
      if (x < y) {return -1;}
      if (x > y) {return 1;}
      return 0;
    })
  }
  SortByDepartment(){
    this.employees.sort(function(a, b){
      let x = a.department?.departmentName.toLowerCase();
      let y = b.department?.departmentName.toLowerCase();
      if (x! < y!) {return -1;}
      if (x! > y!) {return 1;}
      return 0;
    })
  }
  SortByReportingLineManager(){
    this.employees.sort(function(a, b){
      let x = a.reportingLineManager?.name.toLowerCase();
      let y = b.reportingLineManager?.name.toLowerCase();
      if (x!< y!) {return -1;}
      if (x! > y!) {return 1;}
      return 0;
    })
  }
 

}
