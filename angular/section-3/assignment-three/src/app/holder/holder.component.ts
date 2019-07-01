import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-holder',
  templateUrl: './holder.component.html',
  styleUrls: ['./holder.component.css']
})
export class HolderComponent implements OnInit {
  visible = true;
  clicks = [];

  constructor() { }

  ngOnInit() {
  }

  onDisplay() {
    this.visible = !this.visible;
    this.clicks.push(Date.now());
  }

  getBackground(order: number) {
    return this.isMultiItem(order) ? 'blue' : 'white';
  }

  isMultiItem(order: number) {
    return order >= 5;
  }
}
