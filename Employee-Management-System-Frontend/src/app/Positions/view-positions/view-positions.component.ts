import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Position } from 'src/app/Interfaces/position';
import { HttpService } from 'src/app/Services/http.service';

@Component({
  selector: 'app-view-positions',
  templateUrl: './view-positions.component.html',
  styleUrls: ['./view-positions.component.css']
})
export class ViewPositionsComponent implements OnInit {

  constructor(private httpClient:HttpClient, private httpService: HttpService, private router:ActivatedRoute) { }

  positions: Position[] =[]

  GetAllPositions():Observable<Position[]>{
    return this.httpClient.get<Position[]>(this.httpService.httpLink + 'Position/GetAllPositions')
  }

  ngOnInit(): void {
    this.GetAllPositions().subscribe(res=>{
      this.positions = res
    })
  }

  Search(query:string){

  }

  Delete(id:number){
    if(confirm("Are you sure you want to delete this position?")){
      this.httpClient.delete(this.httpService.httpLink + 'Position/DeletePosition/' + id).subscribe(()=>{
        alert("Position deleted successfully")
      },()=>{
        alert("The position was unable to be deleted")
      })
    }
  }

  Update(){
    
  }

}
