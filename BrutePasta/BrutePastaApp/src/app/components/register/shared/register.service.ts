import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Client } from '../../shared/client.model';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private readonly APIURL = 'http://localhost:5000/Client/register'
  constructor(private http: HttpClient) { }

  signUp(clientObj: Client): Observable<Client> {
    return this.http.post<Client>(this.APIURL, clientObj)
  }
}