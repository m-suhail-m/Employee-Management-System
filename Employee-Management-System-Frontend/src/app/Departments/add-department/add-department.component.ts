import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-add-department',
  templateUrl: './add-department.component.html',
  styleUrls: ['./add-department.component.css']
})
export class AddDepartmentComponent implements OnInit {

  constructor(private httpClient:HttpClient, private router:Router, private httpService: HttpService, private fb:FormBuilder) { }

  departmentForm= this.fb.group({
    departmentName:['', Validators.required],
    departmentDescription:['', Validators.required],
    headOfDepartmentId:[0]
  })

  AddDepartment(){
    const departmentForm = this.departmentForm.value

    let department= {
      departmentName: departmentForm.departmentName,
      departmentDescription: departmentForm.departmentDescription,
      // headOfDepartmentId: departmentForm.headOfDepartmentId 
    }
    this.httpClient.post(this.httpService.httpLink + 'Department/AddDepartment', department).subscribe(isGood=>{
      alert("Department added successfully")
    },()=>{
      alert("An error occurred while trying to add the department")
    })
  }

  ngOnInit(): void {
  }

  get departmentName(){return this.departmentForm.get('departmentName')}
  get departmentDescription(){return this.departmentForm.get('departmentDescription')}
  // get headOfDepartmentId(){return this.departmentForm.get('headOfDepartmentId')}

}
