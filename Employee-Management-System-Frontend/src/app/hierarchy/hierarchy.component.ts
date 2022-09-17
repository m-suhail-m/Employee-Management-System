import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Interfaces/employee';
import { HttpService } from '../Services/http.service';

@Component({
  selector: 'app-hierarchy',
  templateUrl: './hierarchy.component.html',
  styleUrls: ['./hierarchy.component.css']
})
export class HierarchyComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService) { }

  ceoList:Employee[] =[]
  cooList:Employee[] =[]
  hodList:Employee[] =[]
  rlmList:Employee[] =[]
  empList:Employee[] =[]

  ceoClick:boolean = false
  cooClick:boolean = false
  hodClick:boolean = false
  rlmClick:boolean = false
  empClick:boolean = false
 
  GetAllEmployees():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.httpService.httpLink + 'Employee/GetAllEmployees')
  }

  CeoClicked(){
    if(this.ceoClick == true){
      this.ceoClick = false
    }
    else{
      this.ceoClick = true
    }
  }

  CooClicked(event:Event){
    if(this.cooClick == true){
      this.cooClick = false
    }
    else{
      this.cooClick = true
    }
  }

  HodClicked(event:Event){
    if(this.hodClick == true){
      this.hodClick = false
    }
    else{
      this.hodClick = true
    }
  }

  RlmClicked(event:Event){
    if(this.rlmClick == true){
      this.rlmClick = false
    }
    else{
      this.rlmClick = true
    }
  }

  EmpClicked(event:Event){
    if(this.empClick == true){
      this.empClick = false
    } 
    else{
      this.empClick = true
    }
  }

  ngOnInit(): void {
    this.GetAllEmployees().subscribe(res=>{
     
      this.ceoList = res.filter(e=> e.position.positionId == 1)
      this.cooList = res.filter(e=> e.position.positionId == 2)
      this.hodList = res.filter(e=> e.position.positionId == 3)
      this.rlmList = res.filter(e=> e.position.positionId == 4)
      this.empList = res.filter(e=> e.position.positionId >= 5)
      
    },()=>{
      this.httpService.FetchError()
    })

   
   
   
  }

}
