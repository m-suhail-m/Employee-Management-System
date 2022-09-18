import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Position } from 'src/app/Interfaces/position';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-update-position',
  templateUrl: './update-position.component.html',
  styleUrls: ['./update-position.component.css']
})
export class UpdatePositionComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService:HttpService, private fb:FormBuilder, private activatedRoute:ActivatedRoute, private router:Router) { }

  position!:Position

  GetPosition():Observable<Position>{
    return this.httpClient.get<Position>(this.httpService.httpLink + 'Position/SearchPositionById/' + this.activatedRoute.snapshot.params['id'])
  }

  positionForm = this.fb.group({
    positionName:['', Validators.required],
    positionDescription:['', Validators.required]
   
  })

  get positionName(){return this.positionForm.get('positionName')}
  get positionDescription(){return this.positionForm.get('positionDescription')}

  UpdatePosition(){
    const positionForm = this.positionForm.value

    let position={
      positionName: positionForm.positionName,
      positionDescription: positionForm.positionDescription
      
    }
    this.httpClient.put(this.httpService.httpLink + 'Position/UpdatePosition/' + this.position.positionId, position).subscribe(()=>{
      alert("Position Updated Successfully")
      this.router.navigate(['view-positions']).then(()=>{location.reload()})
    },()=>{
      alert("An error occurred while trying to update the position")
    })
  }

  Cancel(){
    if(confirm('Cancel and go back?')){
      this.router.navigate(['view-positions'])
    }
    else{
      location.reload()
    }
  }

  ngOnInit(): void {
    this.GetPosition().subscribe(res=>{
      this.position = res

      this.positionForm = this.fb.group({
        positionName:[this.position.positionName, Validators.required],
        positionDescription:[this.position.positionDescription, Validators.required]
      })
  })
  }

}
