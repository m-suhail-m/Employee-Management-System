import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Department } from 'src/app/Interfaces/department';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-update-department',
  templateUrl: './update-department.component.html',
  styleUrls: ['./update-department.component.css']
})
export class UpdateDepartmentComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService, private fb:FormBuilder, private activatedRoute:ActivatedRoute, private router:Router) { }

  department!:Department

  GetDepartment():Observable<Department>{
    return this.httpClient.get<Department>(this.httpService.httpLink + 'Department/SearchDepartmentById/' + this.activatedRoute.snapshot.params['id'])
  }

  departmentForm= this.fb.group({
    departmentName:['', Validators.required],
    departmentDescription:['', Validators.required]

  })

  UpdateDepartment(){
    const departmentForm = this.departmentForm.value

    let department= {
      departmentName: departmentForm.departmentName,
      departmentDescription: departmentForm.departmentDescription,
      // headOfDepartmentId: departmentForm.headOfDepartmentId 
    }
    this.httpClient.put(this.httpService.httpLink + 'Department/UpdateDepartment/' + this.department.departmentId, department).subscribe(isGood=>{
      alert("Department updated successfully")
      this.router.navigate(['view-departments']).then(()=>{location.reload()})
    },()=>{
      alert("An error occurred while trying to update the department")
    })
  }


  Cancel(){
    if(confirm('Cancel and go back?')){
      this.router.navigate(['view-departments'])
    }
    else{
      location.reload()
    }
  }

  get departmentName(){return this.departmentForm.get('departmentName')}
  get departmentDescription(){return this.departmentForm.get('departmentDescription')}

  ngOnInit(): void {

    this.GetDepartment().subscribe(res=>{
      this.department = res

      this.departmentForm= this.fb.group({
        departmentName:[this.department.departmentName, Validators.required],
        departmentDescription:[this.department.departmentDescription, Validators.required]
       
      })
    })

   
  }

}
