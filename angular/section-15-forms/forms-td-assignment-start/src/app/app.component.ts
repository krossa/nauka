import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('f', { static: false }) signupForm: NgForm;
  defaultSubscription = 'Advanced';
  subscriptions = ['Basic', this.defaultSubscription, 'Pro'];

  onSubmit() {
    console.log(this.signupForm);
    // this.signupForm.reset();
  }
}
