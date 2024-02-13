import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../Services/user-services/user.service';
import { CoreService } from '../Services/core-service/core.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-changepass',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './changepass.component.html',
  styleUrl: './changepass.component.css'
})
export class ChangepassComponent implements OnInit {
  passwordDetails!: FormGroup;
  constructor(
    private fb:FormBuilder,
    private userService: UserService,
    private coreService:CoreService,
    private router: Router,
  ){

  }
  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm(){
    this.passwordDetails = this.fb.group({
      // Id: [''],
      // userName: [''],
      // employeeNumber: [''],
      // userType: [''],
      // employeeName: [''],
      // department: [''],
      // employeeId: [''],
      password: ['', Validators.required],
      repassword: ['', Validators.required]
    });
  }

  changepass(){
    if(this.passwordDetails.valid){
      var password = this.passwordDetails.value;
      if(password.password == password.repassword){
        this.userService.getUserInfo().subscribe({
          next:(val:any)=>{
            console.log('emp', val)
            var emp = val;
            emp.password = password.password;
            this.changepassword(emp);
          },
          error:(err:any)=>{
            console.log(err);
          }
        })
      }
    }
  }

  changepassword(emp: any) {
    

    console.log('Id',emp)
    this.userService.updateUser(emp.id, emp).subscribe({
      next: (val: any) => {
        this.coreService.openSnackBar('Password Updated Successfully');
        console.log('Updated password', val);
        this.router.navigate(['Dashboard']);
      },
      error: (err: any) => {
        console.log(err);
      }
    });
  }
  

  getuserinfo() {
    this.userService.getUserInfo().subscribe({
        next: (val: any) => {
            console.log('UserInfo', val);
        }
    });
}
  }

