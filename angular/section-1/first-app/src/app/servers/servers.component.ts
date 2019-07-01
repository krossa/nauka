import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {
  allowNewServer:boolean = false;
  serverCreationStatus = 'No server was created';
  serverName = 'Testserver';
  serverCreted = false;
  servers = ['Testserver', 'Testserver 2'];

  constructor() { 
    setTimeout(() => this.allowNewServer = true, 2000);
  }

  ngOnInit() {
  }

  onCreateServer() {
    this.serverCreted = !this.serverCreted;
    this.serverCreationStatus = 'Server was created name: ' + this.serverName
    this.servers.push(this.serverName);
  }

  onUpdateServerName(event: Event) {
    this.serverName = (<HTMLInputElement>event.target).value;
  }
}
