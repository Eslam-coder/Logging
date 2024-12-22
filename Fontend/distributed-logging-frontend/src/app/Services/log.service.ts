import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LogEntry {
  service: string;
  level: string;
  message: string;
  timestamp: string;
  storageType: string;
}

@Injectable({
  providedIn: 'root'
})
export class LogService {

  private baseUrl = 'https://localhost:7182/api/logs';

  constructor(private http: HttpClient) {}

  getLogs(): Observable<LogEntry[]> {
    return this.http.get<LogEntry[]>(this.baseUrl);
  }

  createLog(log: LogEntry): Observable<LogEntry> {
    return this.http.post<LogEntry>(this.baseUrl, log);
  }
}
