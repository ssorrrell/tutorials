import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard }                from './helpers/canActivateAuthGuard';
import { LoginComponent }   from './components/login/login.component';
import { LogoutComponent }   from './components/login/logout.component';
import { DashboardComponent }   from './components/dashboard/dashboard.component';
import { UsersComponent }      from './components/users/users.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent}, //The page where the user can authenticate
  { path: 'logout', component: LogoutComponent}, //A simple path to log the user out
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] }, //Our home page
  { path: 'users', component: UsersComponent,canActivate: [AuthGuard] } //Our first page where we want to list the users from the back end
  //AuthGuard, which will allow us to check if the user is logged in
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
