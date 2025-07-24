import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model';
import { BaseConfig } from '../config/base-config';

@Injectable({ providedIn: 'root' })
export class BookService {

  constructor(private http: HttpClient,private baseconfig: BaseConfig) {}

 getBooks(page: number = 1, size: number = 10): Observable<Book[]> {
  return this.http.get<Book[]>(`${this.baseconfig.ApiBaseUrl +'api/book/loadallbooks'}?pageNumber=${page}&pageSize=${size}`);
}

}