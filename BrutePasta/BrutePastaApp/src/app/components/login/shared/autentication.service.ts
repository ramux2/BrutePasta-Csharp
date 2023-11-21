import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

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
    return localStorage.getItem('token')
  }

  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log("Objeto descriptado", jwtHelper.decodeToken(token));
    return jwtHelper.decodeToken(token);
  }
}
