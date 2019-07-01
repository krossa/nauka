import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css']
})
export class GameControlComponent implements OnInit {
  @Output() timerUpdated = new EventEmitter<number>();
  counter = 0;
  timer: NodeJS.Timer;

  constructor() { }

  ngOnInit() {
  }

  onStartGame() {
    this.timer = setInterval(() => this.count(), 1000);
    console.log('game start');
  }

  onStopGame() {
    clearInterval(this.timer);
  }

  count() {
    this.counter++;
    this.timerUpdated.emit(this.counter);
    console.log('count: ' + this.counter);
  }
}
