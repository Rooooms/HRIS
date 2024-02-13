import { Component } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { UserService } from '../../Services/user-services/user.service';
import { CoreService } from '../../Services/core-service/core.service';
import { AddEditUserComponent } from '../add-edit-user/add-edit-user.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [MaterialModule ],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {

  constructor(public dialog: MatDialog, private userService : UserService, private coreService:CoreService){}

  displayedColumns: string[] = ['employeeName', 'employeeNumber', 'userType', 'department', 'actions'];
 
  dataSource!: MatTableDataSource<any>;
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  ngOnInit(): void {
   
    this.getUser();
  }
  // openAddEditDialog(): void {
  //   console.log('Opening AddEditDialog...');
  //   const dialogRef = this.dialog.open(AddEdit201FileComponent);

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddEditUserComponent, {
      width: '700px',
      height: 'auto',
      maxHeight: '90vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openEditForm(data: any) {
    const dialogRef = this.dialog.open(AddEditUserComponent, {
      data: data,  // Pass the data to the dialog
    });
  
    dialogRef.afterClosed().subscribe({
      next: (bookDetails) => {
        if (bookDetails) {
          this.getUser();
        }
      },
    });
  }

  // openDialogDashboard(data: any) {
  //   const dialogRef = this.dialog.open(DialogDashboardComponent, {
  //     width: '1000px',
  //     height: 'auto',
  //     maxHeight: '90vw',  
  //     data: data,  // Pass the data to the dialog
  //   });
  
  //   dialogRef.afterClosed().subscribe({
  //     next: (employeeDetails) => {
  //       if (employeeDetails) {
  //         this.getEmployeeDetails();
  //       }
  //     },
  //   });
  // }
 

  getUser():void{
    this.userService.getUser().subscribe({
      next:(val:any)=>{
        if(Array.isArray(val)){
          this.dataSource = new MatTableDataSource(val);
        }
        else{
          this.coreService.openSnackBar('User is not an Array')
        }
      },
      error: (error) => {
        console.error('Error fetching Employee Details Data:', error);
      }
    })
  }

 
  
  
  
  

  // deleteEmployee(id: string): void {
  //   const isConfirmed = window.confirm('Are you sure you want to delete this data?');
  
  //   if (isConfirmed) {
  //     this.employeeDetailsService.deleteEmployeeDetails(id).subscribe({
  //       next: (empDetails) => {
  //         this.getEmployeeDetails();
  //       },
  //       error: console.log
  //     });
  //   }
  
  // }
}
