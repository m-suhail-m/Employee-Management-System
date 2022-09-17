import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Department } from 'src/app/Interfaces/department';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-view-departments',
  templateUrl: './view-departments.component.html',
  styleUrls: ['./view-departments.component.css']
})
export class ViewDepartmentsComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService: HttpService, private router:ActivatedRoute) { }

  departments:Department[] =[] 

  GetAllDepartments():Observable<Department[]>{
    return this.httpClient.get<Department[]>(this.httpService.httpLink + 'Department/GetAllDepartments')
  }

  Delete(id:number){
    if(confirm("Are you sure you want to delete this department?")){
      this.httpClient.delete(this.httpService.httpLink + 'Department/DeleteDepartment/' + id).subscribe(()=>{
        alert("Department deleted successfully")
      },()=>{
        alert("The department was unable to be deleted")
      })
    }
  }

  ngOnInit(): void {
    this.GetAllDepartments().subscribe(res=>{
      this.departments = res
    })
  }

}
