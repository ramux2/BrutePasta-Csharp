import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AutenticationService {
  private readonly APIRUL = 'http://localhost:5000/Client/authenticate'

  constructor(private http: HttpClient) { }

  autenticate(clientObj: any): Observable<any> {
    return this.http.post<any>(this.APIRUL, clientObj)
  }

  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue)
  }

  getToken() {
    localStorage.getItem('token')
  }
}
