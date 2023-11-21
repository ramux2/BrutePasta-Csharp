import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Client } from '../../shared/client.model';

const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly APIRUL = 'http://localhost:5000/Client/client'
  private email$ = new BehaviorSubject<string>("");

  constructor(private http: HttpClient) { }

  public getEmailFromStore(){
    return this.email$.asObservable();
  }

  public setEmailForStore(email:string){
    this.email$.next(email);
  }

  getUser(email: string): Observable<Client> {
    const encodedEmail = encodeURIComponent(email);
    const url = `${this.APIRUL}/${encodedEmail}`;
    return this.http.get<Client>(url);
  }
}
