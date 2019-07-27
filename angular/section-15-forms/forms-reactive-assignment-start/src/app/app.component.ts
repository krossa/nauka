import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  signupForm: FormGroup;
  statuses = ['Stable', 'Critical', 'Finished'];

  ngOnInit() {
    this.signupForm = new FormGroup({
      'project': new FormControl(null, [Validators.required, this.validateProject.bind(this)]),
      'email': new FormControl(null, [Validators.required, Validators.email], this.validateEmailAsync),
      'status': new FormControl('Critical')
    });
  }

  onSubmit() {
    console.log(this.signupForm);
  }


  validateProject(control: FormControl): { [s: string]: boolean } {
    if (control.value === 'test') {
      return { 'invalidName': true };
    }
    return null;
  }

  validateEmailAsync(control: FormControl): Promise<any> | Observable<any> {
    const promise = new Promise<any>((resolve, _reject) => {
      setTimeout(() => {
        if (control.value === 'test@test.com') {
          resolve({ 'invalidEmail': true });
        } else {
          resolve(null);
        }
      }, 1500);
    });
    return promise;
  }
}
