import { Component } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { UserInfo } from 'os';
import { UserService } from '../Services/user-services/user.service';


@Component({
  selector: 'app-app-layout',
  standalone: true,
  imports: [
    MaterialModule
    
  ],
  templateUrl: './app-layout.component.html',
  styleUrl: './app-layout.component.css'
})
export class AppLayoutComponent {
  constructor(private userService:UserService){}

  logout(){
    this.userService.logout();
  }
}
