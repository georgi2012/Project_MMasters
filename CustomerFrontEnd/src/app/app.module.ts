import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule ,FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { RouterModule } from '@angular/router';
import { UserService } from './shared/user-services/user.service';
import {HttpClientModule} from "@angular/common/http"

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { MatDialogModule } from '@angular/material/dialog';//popups
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './frontpage/home/home.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ArmyComponent } from './frontpage/army/army.component';
import { UsersComponent } from './frontpage/users/users.component';
import { StoreComponent } from './frontpage/store/store.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ForbiddenComponent,
    FrontpageComponent,
    ArmyComponent,
    UsersComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    NgbModule,
    ToastrModule.forRoot({
      progressBar:true
    }),
  ],
  providers: [UserService], //added
  bootstrap: [AppComponent]
})
export class AppModule { }
