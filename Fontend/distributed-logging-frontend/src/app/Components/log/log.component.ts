import { Component, OnInit } from '@angular/core';
import { LogEntry, LogService } from '../../Services/log.service';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})

export class LogComponent implements OnInit {

  logs: LogEntry[] = [];
  displayedColumns: string[] = ['Service', 'Level', 'Message', 'Timestamp'];

  constructor(private logService: LogService) {}

  ngOnInit(): void {
    this.logService
        .getLogs()
        .subscribe((data) => {
          this.logs = data;
    });
  }
}
