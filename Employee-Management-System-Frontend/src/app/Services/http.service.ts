import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  httpLink:string = 'https://employeemanagement.com/aai/'

  FetchError(){
    alert("An error occurred while trying to fetch the data")
  }


}
