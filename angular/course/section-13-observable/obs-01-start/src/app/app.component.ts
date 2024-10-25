import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from './user.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  private activatesSub: Subscription;
  userActivated = false;
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.activatesSub = this.userService.activatedEmmiter.subscribe((activated: boolean) => {
      this.userActivated = activated;
    });
  }

  ngOnDestroy(): void {
    this.activatesSub.unsubscribe();
  }
}
