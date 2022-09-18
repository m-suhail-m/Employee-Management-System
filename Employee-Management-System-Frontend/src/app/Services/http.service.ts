import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  // httpLink:string = 'http://msuhailm-001-site1.htempurl.com/api/'

  httpLink:string = 'https://localhost:44357/api/'

  FetchError(){
    alert("An error occurred while trying to fetch the data")
  }


}
