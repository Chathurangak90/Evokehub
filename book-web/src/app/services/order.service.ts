import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';
import { BaseConfig } from '../config/base-config';

@Injectable({ providedIn: 'root' })
export class OrderService {

  constructor(private http: HttpClient,private baseconfig: BaseConfig) {}

  placeOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.baseconfig.ApiBaseUrl +'api/Order/createorder', order);
  }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.baseconfig.ApiBaseUrl +'api/Order/getorders');
  }
}
