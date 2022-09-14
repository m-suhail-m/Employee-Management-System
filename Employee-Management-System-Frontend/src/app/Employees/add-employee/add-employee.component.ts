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

    this.today = Date.now()
  }

 today = 0

  employeeForm = this.fb.group({
    name:['', [Validators.required]],
    surname:['',[Validators.required]],
    birthDate:['',[Validators.required]],
    salary:[0,[Validators.required, Validators.min(1)]],
    position:[0,[Validators.required, Validators.min(1)]],
    department:[0],
    reportingLineManagerId:[0]
  })

  
  get name(){return this.employeeForm.get('name')}
  get surname(){return this.employeeForm.get('surname')}
  get birthDate(){return this.employeeForm.get('birthDate')}
  get salary(){return this.employeeForm.get('salary')}
  get position(){return this.employeeForm.get('position')}

  employees:Employee[] =[]

  GetEmployees():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllEmployees')
  }
  
  AddEmployee(){
   const employeeForm = this.employeeForm.value
    let employee={
      name:employeeForm.name,
      surname:employeeForm.surname,
      birthDate: employeeForm.birthDate,
      salary: parseFloat(employeeForm.salary),
      positionId: employeeForm.position*1,
      departmentId: employeeForm.department*1,
      reportingLineManagerId: employeeForm.reportingLineManagerId*1
    }

    this.httpClient.post(this.httpService.httpLink + 'Employee/AddEmployee', employee).subscribe(isGood=>{
      alert("Employee Added Successfully")
    },isBad=>{
      alert("An error occurred while trying to add the employee")
    })
  }

}

// name:string, surname:string, birth:string, salary:string, position:string, reportingLineManagerId:string
//name.value, surname.value, birth.value, salary.value, position.value, manager.value