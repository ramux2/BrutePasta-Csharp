import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from './order.model';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
}

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly APIURL = 'http://localhost:5000/Order/order'
  constructor(private http: HttpClient) { }
  
  createOrder(Order: Order): Observable<Order> {
    const url = `${this.APIURL}/order`;
    return this.http.post<Order>(this.APIURL, Order);
  }
}
