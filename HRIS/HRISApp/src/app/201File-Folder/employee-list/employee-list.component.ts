import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { EmployeeDetailsService } from '../../Services/employee-details-service/employee-details.service';
import { Add201fileComponent } from '../add201file/add201file.component';
import { Edit201fileComponent } from '../edit201file/edit201file.component';
import { DialogDashboardComponent } from '../dialog-dashboard/dialog-dashboard.component';
import { MatRadioButton, MatRadioModule } from '@angular/material/radio';

import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatRadioModule,
    CommonModule
    
  ],
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  selectedStatus: string = '';
  employeeStatusOptions: string[] = ['Active', 'InActive'];
  constructor(public dialog: MatDialog, private employeeDetailsService : EmployeeDetailsService, private cdr: ChangeDetectorRef){}

  displayedColumns: string[] = ['name', 'employeeNumber', 'ccNo', 'actions'];
 
  dataSource!: MatTableDataSource<any>;
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  ngOnInit(): void {
   
    this.getEmployeeDetails();
  }
  // openAddEditDialog(): void {
  //   console.log('Opening AddEditDialog...');
  //   const dialogRef = this.dialog.open(AddEdit201FileComponent);

  openAddDialog(): void {
    const dialogRef = this.dialog.open(Add201fileComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openDialogDashboard(data: any) {
    const dialogRef = this.dialog.open(DialogDashboardComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',  
      data: data,  // Pass the data to the dialog
    });
  
    dialogRef.afterClosed().subscribe({
      next: (employeeDetails) => {
        if (employeeDetails) {
          this.getEmployeeDetails();
        }
      },
    });
  }
  onStatusChange(): void {
    this.getEmployeeDetails();
  }

  getEmployeeDetails(): void {
    console.log('Fetching employee details...');
    this.employeeDetailsService.getEmployeeDetails().subscribe({
      next: (empDetails) => {
        console.log('Fetched employee details:', empDetails);
  
        if (Array.isArray(empDetails)) {
          this.dataSource = new MatTableDataSource(empDetails);
        } else {
          console.error('Employee Details Data is not an array.');
        }
      },
      error: (error) => {
        console.error('Error fetching Employee Details Data:', error);
      }
    });
  }
  
  
  
  

  deleteEmployee(id: string): void {
    const isConfirmed = window.confirm('Are you sure you want to delete this data?');
  
    if (isConfirmed) {
      this.employeeDetailsService.deleteEmployeeDetails(id).subscribe({
        next: (empDetails) => {
          this.getEmployeeDetails();
        },
        error: console.log
      });
    }
  
  }
}

