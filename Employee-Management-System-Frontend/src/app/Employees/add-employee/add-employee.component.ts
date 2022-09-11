import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/Interfaces/employee';
import { HttpService } from 'src/app/Services/http.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService, private fb:FormBuilder) { }

  ngOnInit(): void {
    this.GetEmployees().subscribe(res=>{
      this.employees = res
      console.log(this.employees)
    },()=>{
      this.httpService.FetchError()
    })
  }

  employeeForm = this.fb.group({
    name:['', [Validators.required]],
    surname:['',[Validators.required]],
    birthDate:['',[Validators.required,]],
    salary:['',[Validators.required, Validators.min(0)]],
    position:['',[Validators.required]],
    reportingLineManagerId:['']
  })

  // AddEmployee(){
  //   this.httpClient.post("")
  // }

  employees:Employee[] =[]
  formValue=''

  GetEmployees():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllEmployees')
  }
  
  AddEmployee(name:string, surname:string, birth:string, salary:string, position:string, reportingLineManagerId:string){
    let employee={
      name:name,
      surname:surname,
      birthDate: birth,
      salary: parseFloat(salary) ,
      position:position,
      reportingLineManagerId: parseInt(reportingLineManagerId)
    }

    this.httpClient.post(this.httpService.httpLink + 'Employee/AddEmployee', employee).subscribe(isGood=>{
      alert("Employee Added Successfully")
    },isBad=>{
      alert("An error occurred while trying to add the employee")
    })
  }

}

// 