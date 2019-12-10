import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  numbers: { type: string, value: number }[] = [];

  onTimerUpdated(counter: number) {
    console.log('app component');
    this.numbers.push({
      type: counter % 2 === 0 ? 'even' : 'odd',
      value: counter
    });
  }
}
