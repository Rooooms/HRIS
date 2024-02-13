import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { UserInfo } from 'os';
import { UserService } from '../Services/user-services/user.service';
import { CommonModule } from '@angular/common';
import { MatExpansionModule } from '@angular/material/expansion';


@Component({
  selector: 'app-app-layout',
  standalone: true,
  imports: [
    MaterialModule,
    CommonModule,
    MatExpansionModule
    
  ],
  templateUrl: './app-layout.component.html',
  styleUrl: './app-layout.component.css'
})
export class AppLayoutComponent implements OnInit{
  panelOpenState = false;
  public role : string="";

  constructor(private userService:UserService){}

  ngOnInit(): void {
    this.userService.getRole()
    .subscribe(val=>{
      let roleFromToken= this.userService.getRoleFromToken();
      this.role = val || roleFromToken
      console.log('Role', roleFromToken)
    })
  }

  logout(){
    this.userService.logout();
  }


  
}
