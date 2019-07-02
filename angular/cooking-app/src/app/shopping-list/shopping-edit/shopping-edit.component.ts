import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { Ingridient } from 'src/app/shared/ingridient.model';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @ViewChild('amountInput') amountInput: ElementRef;
  @ViewChild('nameInput') nameInput: ElementRef;
  @Output() ingridientAdded = new EventEmitter<Ingridient>();

  constructor() { }

  ngOnInit() {
  }

  onAdd() {
    const item = new Ingridient(this.nameInput.nativeElement.value, this.amountInput.nativeElement.value);
    this.ingridientAdded.emit(item);
  }
}
