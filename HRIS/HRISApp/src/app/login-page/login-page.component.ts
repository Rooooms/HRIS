import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../Services/user-services/user.service';
import { Router } from '@angular/router';
import { error } from 'console';
import { CoreService } from '../Services/core-service/core.service';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnInit, AfterViewInit {
  loginForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService, // Inject your authentication service
    private router: Router,
    private coreService :CoreService
  ) {}
 

  ngOnInit() {
    this.initializeForm();

    
  }

  ngAfterViewInit(): void {
   
  }

  initializeForm() {
    this.loginForm = this.formBuilder.group({
      employeeNumber: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // login() {
  //   if (this.loginForm.valid) {
  //     const { userName, password } = this.loginForm.value;

  //     // Call your authentication service for login
  //     this.userService.login(userName, password).subscribe(
  //       (response) => {
  //         // Authentication successful
  //         console.log('Login successful');
  //         // Navigate to the dashboard
  //         this.router.navigate(['/Dashboard']);
  //       },
  //       (error) => {
  //         // Handle authentication error (invalid credentials, etc.)
  //         console.error('Login failed', error);
  //       }
  //     );
  //   } else {
  //     // Form is invalid, display an error or handle it accordingly
  //     console.error('Form is invalid');
  //   }
  // }

  login() {
    if (this.loginForm.valid) {
      this.userService.login(this.loginForm.value).subscribe(
        (res: any) => {
          console.log('Login successful', res.token);
          this.loginForm.reset();
          this.userService.handleLoginSuccess(res.token);
          const tokenPayload = this.userService.decodeToken();
          this.userService.setRole(tokenPayload.role);
          console.log('Token stored:', localStorage.getItem('token'));
          this.coreService.openSnackBar('Login Successfully!')

          
          if (res.isTemporaryPassword) {
            // Redirect to change password page
            this.getuserinfo();
            this.router.navigate(['changepass']);
          } else {
            this.getuserinfo();
            this.router.navigate(['Dashboard']);
          }
        },
        (err: any) => {
          console.log('Login error', err);
          this.coreService.openSnackBar('Login Error!')
  
          // Check for specific HTTP status codes
          if (err.status === 401) {
            console.log('Account does not exist or invalid credentials.');
          } else {
            console.error('Unexpected error during login.', err);
          }
  
          // Rethrow the error to prevent navigation
          throw err;
        }
      );
    }
  }

  getuserinfo() {
    this.userService.getUserInfo().subscribe({
        next: (val: any) => {
            console.log('UserInfo', val);
        }
    });
}

  
  
  
  
  
}
