import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Department } from 'src/app/Interfaces/department';
import { Employee } from 'src/app/Interfaces/employee';
import { Position } from 'src/app/Interfaces/position';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService, private fb:FormBuilder, private activatedRoute:ActivatedRoute, private datePipe:DatePipe, private router:Router) { }

  reportingLineManagers:Employee[] =[]
  departments: Department[] =[]
  positions: Position[] =[]
  employee!: Employee


  GetReportingLineManagers():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllReportingLineManagers')
  }
  GetDepartments():Observable<Department[]>{
    return this.httpClient.get<Department[]>(this.httpService.httpLink + 'Department/GetAllDepartments')
  }
  GetPositions():Observable<Position[]>{
    return this.httpClient.get<Position[]>(this.httpService.httpLink + 'Position/GetAllPositions')
  }
  GetEmployeeDetails():Observable<Employee>{
    return this.httpClient.get<Employee>(this.httpService.httpLink + 'Employee/SearchEmployeeById/' + this.activatedRoute.snapshot.params['id'])
  }

  RemoveSelfFromReportingLineManagers(){
    if(this.employee.position.positionName =="Reporting Line Manager"){
      let e = this.reportingLineManagers.find(e=>e.reportingLineManagerId == this.employee.employeeId)
      let i = this.reportingLineManagers.indexOf(e!)
      this.reportingLineManagers.splice(i,1)
    }
  }

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

  UpdateEmployee(){
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
    this.httpClient.put(this.httpService.httpLink + 'Employee/UpdateEmployee/' + this.employee.employeeId, employee).subscribe(()=>{
     alert("Employee updated successfully")
      this.router.navigate(['view-employees']).then(()=>{location.reload()})
    }, ()=>{
      alert("An error occurred while trying to update the employee")
    })
  }

  Cancel(){
    if(confirm('Cancel and go back?')){
      this.router.navigate(['view-employees']).then(()=>{location.reload()})
    }
    else{
      location.reload()
    }
  }

  ngOnInit(): void {
    this.GetReportingLineManagers().subscribe(res=>{
      this.reportingLineManagers = res
     
    })

    this.GetDepartments().subscribe(res=>{
      this.departments = res
     
    })

    this.GetPositions().subscribe(res=>{
      this.positions = res
     
    })

    this.GetEmployeeDetails().subscribe(res=>{
      this.employee = res
     
      this.RemoveSelfFromReportingLineManagers()
      
      console.log(this.reportingLineManagers)

      this.employeeForm = this.fb.group({
          name:[this.employee.name, [Validators.required]],
          surname:[this.employee.surname,[Validators.required]],
          birthDate:[this.datePipe.transform(this.employee.birthDate,'yyyy-MM-dd'),[Validators.required]],
          salary:[this.employee.salary,[Validators.required, Validators.min(1)]],
          position:[this.employee.positionId,[Validators.required, Validators.min(1)]],
          department:[this.employee.departmentId],
          reportingLineManagerId:[this.employee.reportingLineManagerId]
      })

       
       
    })
  }
}
