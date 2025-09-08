// src/app/core/auth/register/register.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface RegisterPayload {
  username: string;
  email: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private apiUrl = 'http://localhost:5067//api/register'; // Replace with your real API

  constructor(private http: HttpClient) {}

  register(data: RegisterPayload): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
}
