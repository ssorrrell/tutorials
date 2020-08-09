import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {
  title = 'angular-sample';
  
  subscription: Subscription;
  authentication: boolean;
  constructor(private helpers: Helpers) {
  }
  
  ngAfterViewInit() {
    this.subscription = this.helpers.isAuthenticationChanged().pipe(
      startWith(this.helpers.isAuthenticated()),
      delay(0)).subscribe((value) =>
        this.authentication = value
      );
  }
  
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
