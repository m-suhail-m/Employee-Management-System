import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { position } from 'html2canvas/dist/types/css/property-descriptors/position';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-add-position',
  templateUrl: './add-position.component.html',
  styleUrls: ['./add-position.component.css']
})
export class AddPositionComponent implements OnInit {

  constructor(private httpClient:HttpClient,private router:Router,private fb:FormBuilder, private httpService:HttpService) { }

  ngOnInit(): void {
  }

  positionForm = this.fb.group({
    positionName:['', Validators.required],
    positionDescription:['', Validators.required]
   
  })

  Cancel(){
    location.reload()
  }

  AddPosition(){
    const positionForm = this.positionForm.value

    let position={
      positionName: positionForm.positionName,
      positionDescription: positionForm.positionDescription
      //,
      // hasDepartment: positionForm.hasDepartment,
      // hasReportingLineManager: positionForm.hasReportingLineManager
    }
    this.httpClient.post(this.httpService.httpLink + 'Position/AddPosition' , position).subscribe(()=>{
      alert("Position Added Successfully")
    },()=>{
      alert("An error occurred while trying to add the position")
    })
  }

  get positionName(){return this.positionForm.get('positionName')}
  get positionDescription(){return this.positionForm.get('positionDescription')}
  // get hasDepartment(){return this.positionForm.get('hasDepartment')}
  // get hasReportingLineManager(){return this.positionForm.get('hasReportingLineManager')}

}
