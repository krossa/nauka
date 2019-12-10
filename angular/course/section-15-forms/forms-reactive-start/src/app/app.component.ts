import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray, Form } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  genders = ['male', 'female'];
  signupForm: FormGroup;
  forbiddenUsernames = ['krowa']

  ngOnInit() {
    this.signupForm = new FormGroup({
      'userData': new FormGroup({
        'username': new FormControl(null, [Validators.required, this.validateUsername.bind(this)]),
        'email': new FormControl(null, [Validators.required, Validators.email], this.validateEmail)
      }),
      'gender': new FormControl('male'),
      'hobbies': new FormArray([])
    });
    this.signupForm.valueChanges.subscribe(
      (value) => { console.log(value) }
    );
    this.signupForm.statusChanges.subscribe(
      (value) => { console.log(value) }
    );

    this.signupForm.setValue({
      'userData' : {
        'username' : 'karol',
        'email': 'my@test.com'
      },
      'gender': 'male',
      'hobbies': []
    });

    this.signupForm.patchValue({
      'userData' : {
        'username' : 'anna'
      }
    });
  }

  onSubmit() {
    console.log(this.signupForm);
    this.signupForm.reset();
  }

  onAddHobby() {
    let control = new FormControl(null, Validators.required);
    (<FormArray>this.signupForm.get('hobbies')).push(control);
  }

  getHobbies() {
    return (<FormArray>this.signupForm.get('hobbies')).controls
  }

  validateUsername(control: FormControl): { [s: string]: boolean } {
    if (!this.forbiddenUsernames.indexOf(control.value)) {
      return { 'invalidName': true };
    }
    return null;
  }

  validateEmail(control: FormControl): Promise<any> | Observable<any> {
    const promise = new Promise<any>((resolve, reject) => {
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
