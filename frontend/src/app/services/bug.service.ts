// src/app/services/task.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bug } from '../models/bug';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BugService {
  private apiUrl: string;

  constructor(private http: HttpClient) {
    if (window.location.hostname === 'localhost') {
      this.apiUrl = 'http://localhost:5049/bugs';
    } else {
      this.apiUrl = '/api/bugs';
    }
  }

  getBugs(): Observable<Bug[]> {
    return this.http.get<Bug[]>(this.apiUrl);
  }

  getBug(id: number): Observable<Bug> {
    return this.http.get<Bug>(`${this.apiUrl}/${id}`);
  }

  createBug(bug: Bug): Observable<Bug> {
    return this.http.post<Bug>(this.apiUrl, bug);
  }

  updateBug(bug: Bug): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${bug.id}`, bug);
  }

  deleteBug(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
