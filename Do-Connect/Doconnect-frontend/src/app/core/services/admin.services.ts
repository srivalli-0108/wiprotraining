// src/app/services/admin.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl = 'http://localhost:5067/api/admin'; // Update with your actual backend URL

  constructor(private http: HttpClient) {}

  getNotifications(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/notifications`);
  }

  getPendingQuestions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/pending-questions`);
  }

  getPendingAnswers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/pending-answers`);
  }

  approveQuestion(id: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/approve-question/${id}`, {});
  }

  rejectQuestion(id: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/reject-question/${id}`, {});
  }

  approveAnswer(id: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/approve-answer/${id}`, {});
  }

  rejectAnswer(id: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/reject-answer/${id}`, {});
  }
}
