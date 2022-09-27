import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ArmyComponent } from './frontpage/army/army.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { HomeComponent } from './frontpage/home/home.component';
import { StoreComponent } from './frontpage/store/store.component';
import { UsersComponent } from './frontpage/users/users.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},//default

  {path:'user',component:UserComponent,
children:[
  {path:'registration',component:RegistrationComponent},//user/registration
  {path:'login',component:LoginComponent}]},//user/login
  {path:'page',component:FrontpageComponent,canActivate:[AuthGuard],
  children:[
{path:'home',component:HomeComponent,canActivate:[AuthGuard]},
{path:'army',component:ArmyComponent,canActivate:[AuthGuard]},
{path:'store',component:StoreComponent,canActivate:[AuthGuard]},
{path:'users',component:UsersComponent,canActivate:[AuthGuard],data:{permittedRoles:['Admin']}}
  ]},
{path:'forbidden',component:ForbiddenComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
