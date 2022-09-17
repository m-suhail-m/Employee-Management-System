import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/Interfaces/employee';
import { HttpService } from 'src/app/Services/http.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Department } from 'src/app/Interfaces/department';
import { Position } from 'src/app/Interfaces/position';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})

export class AddEmployeeComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService, private fb:FormBuilder) { }

  reportingLineManagers:Employee[] =[]
  departments: Department[] =[]
  positions: Position[] =[]
  selectedPosition! : Position

  GetReportingLineManagers():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllReportingLineManagers')
  }
  GetDepartments():Observable<Department[]>{
    return this.httpClient.get<Department[]>(this.httpService.httpLink + 'Department/GetAllDepartments')
  }
  GetPositions():Observable<Position[]>{
    return this.httpClient.get<Position[]>(this.httpService.httpLink + 'Position/GetAllPositions')
  }

  

  employeeForm = this.fb.group({
    name:['', [Validators.required]],
    surname:['',[Validators.required]],
    birthDate:['',[Validators.required]],
    salary:[0,[Validators.required, Validators.min(1)]],
    position:[0,[Validators.required]],
    department:[0],
    reportingLineManagerId:[0]
  })

  
  get name(){return this.employeeForm.get('name')}
  get surname(){return this.employeeForm.get('surname')}
  get birthDate(){return this.employeeForm.get('birthDate')}
  get salary(){return this.employeeForm.get('salary')}
  get position(){return this.employeeForm.get('position')}

  HasDepartment():boolean{
    let positionId:number = this.employeeForm.value.position
    let position = this.positions.find(p=> p.positionId == positionId)
   
    if(position?.hasDepartment){
      return true
    }
   else{
    return false
   }
  }

  HasReportingLineManager(){
    let positionId:number = this.employeeForm.value.position
    let position = this.positions.find(p=> p.positionId == positionId)
   
    if(position?.hasReportingLineManager){
      return true
    }
   else{
    return false
   }
  }

  // GetPosition(){
  //   let positionId:number = this.employeeForm.value.position
  //   let position = this.positions.find(p=> p.positionId == positionId)
  //   this.selectedPosition = position!
  //   console.log(this.selectedPosition)
  // }
  
  // PositionSelected():boolean{
  //   if(this.employeeForm.value.position == 0){
  //     return false
  //   }
  //   else if(this.employeeForm.value.position == 1){
  //     this.employeeForm.value.department = 0
  //     this.employeeForm.value.reportingLineManagerId = 0
  //     return false
  //   }
  //   else{
  //     return true
  //   }
  // }
  
  // HasDepartment():boolean{
  //   let index = this.employeeForm.value.position
  
  //   for(let i = 0; i < this.positions.length; i++){

  //     if(this.positions[i].positionId== index){
  //       if(this.positions[i].positionName == "CEO")
  //       // this.employeeForm.value.department = 0
  //       return false
  //     }
  //   }
  //     if(index == 0){
  //       return false
  //     }
  //     return true
    
  // }

  // HasReportingLineManager():boolean{
  //   let index = this.employeeForm.value.position
  //   if(!this.HasDepartment()){
  //     return false
  //   }

  //   else if()
  //   return true
  // }
  
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

   
  }

}

// name:string, surname:string, birth:string, salary:string, position:string, reportingLineManagerId:string
//name.value, surname.value, birth.value, salary.value, position.value, manager.value