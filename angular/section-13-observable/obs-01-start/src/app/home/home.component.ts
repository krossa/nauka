import { Component, OnInit, OnDestroy } from '@angular/core';

import { interval, Subscription, Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  private firstSubscription: Subscription;

  constructor() { }

  ngOnInit() {
    // this.firstSubscription = interval(1000).subscribe(count => {
    //   console.log(count);
    // });
    const customIntervalObsevable = new Observable(observer => {
      let count = 0;
      setInterval(() => {
        observer.next(count);
        if (count === 2) {
          observer.complete();
        }
        if (count > 3) {
          observer.error(new Error('count is greater then 3'));
        }
        count++;
      }, 1000);
    });

    this.firstSubscription = customIntervalObsevable.pipe(
      filter(this.filterData),
      map(this.mapData))
      .subscribe(
        this.subscribeData,
        this.errorData,
        this.completeData);
  }

  ngOnDestroy() {
    this.firstSubscription.unsubscribe();
  }

  filterData(data: number) {
    return data > 0;
  }

  mapData(data: number) {
    return 'Round: ' + (data + 1);
  }
  subscribeData(data: any) {
    console.log(data);
  }

  errorData(data) {
    alert(data);
  }

  completeData() {
    console.log('complete');
  }
}
