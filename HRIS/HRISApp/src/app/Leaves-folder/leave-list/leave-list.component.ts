import { Component, OnInit, ViewChild } from '@angular/core';
import { LeavesService } from '../../Services/leaves-service/leaves.service';
import { MaterialModule } from '../../material/material.module';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { DatePipe } from '@angular/common';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { LeavesDetailsComponent } from '../leaves-details/leaves-details.component';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-leave-list',
  standalone: true,
  imports: [
    MaterialModule,
    MatTableModule,
  ],
  templateUrl: './leave-list.component.html',
  styleUrl: './leave-list.component.css'
})
export class LeaveListComponent implements OnInit{
  selected?: any;
  newval:any[]=[];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  dataSource!: MatTableDataSource<any>;
  constructor(private leaveService : LeavesService, private datePipe: DatePipe, private leavesFb: FormBuilder,public dialog: MatDialog){
    
  }

  displayedColumns: string[] = ['dateSubmitted','leaveStartDate', 'leaveEndDate', 'reason','status', 'details'];


  ngOnInit(): void {
    this.getLeaveList();
  }




  getLeaveList() {
    this.leaveService.getLeaves().subscribe({
      next: (val: any) => {
        console.log('Leave List', val);
  
        if (Array.isArray(val)) {
          // Format the date before assigning it to the dataSource
          val.forEach((item: any) => {
            item.dateSubmitted = this.datePipe.transform(item.dateSubmitted, 'MMMM dd, yyyy');
            item.leaveStartDate = this.datePipe.transform(item.leaveStartDate, 'MMMM dd, yyyy');
            item.leaveEndDate = this.datePipe.transform(item.leaveEndDate, 'MMMM dd, yyyy');
            // Repeat this for other date fields if needed
          });
  
          this.dataSource = new MatTableDataSource(val);
          this.dataSource.sort = this.sort;
          this.dataSource.paginator = this.paginator;
          
        
        } else {
          console.error('Employee Details Data is not an array.');
        }
      },
      error: (err: any) => {
        console.log('Error', err);
      }
    });
  }

  openLeaveDetails(data:any){
    const dialogRef = this.dialog.open(LeavesDetailsComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data:data,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
 
 
  
  
  
  

}
