import { Component, OnInit, ViewChild } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { UserService } from '../../Services/user-services/user.service';
import { LeavesService } from '../../Services/leaves-service/leaves.service';
import { DatePipe } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { LeavesDetailsComponent } from '../leaves-details/leaves-details.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { ManageLeaveStatusComponent } from '../manage-leave-status/manage-leave-status.component';

@Component({
  selector: 'app-manage-leave',
  standalone: true,
  imports: [
    MaterialModule,
    MatTableModule,
    MatPaginatorModule
  ],
  templateUrl: './manage-leave.component.html',
  styleUrl: './manage-leave.component.css'
})
export class ManageLeaveComponent implements OnInit{
  @ViewChild(MatPaginator) requestedPaginator!: MatPaginator;
  @ViewChild(MatPaginator) approvedPaginator!: MatPaginator;
  @ViewChild(MatPaginator) deniedPaginator!: MatPaginator;
  @ViewChild('cancelledPaginator') cancelledPaginator!: MatPaginator;
  @ViewChild(MatSort) requestedSort!: MatSort;
  @ViewChild(MatSort) approvedSort!: MatSort;
  @ViewChild('deniedSort', { static: true }) deniedSort!: MatSort;
  @ViewChild('cancelledSort', { static: true }) cancelledSort!: MatSort;
  
  displayedColumns: string[] = ['dateSubmitted','leaveStartDate', 'leaveEndDate', 'reason','status', 'details'];

  constructor(private userService : UserService,
              private leaveService : LeavesService,
              private datePipe: DatePipe,
              private dialog : MatDialog){

  }
  requestedLeavesDataSource!: MatTableDataSource<any>;
  approvedLeavesDataSource!: MatTableDataSource<any>;
  deniedLeavesDataSource!: MatTableDataSource<any>;
  cancelledLeavesDataSource!: MatTableDataSource<any>;
  
  
  ngOnInit(): void {
    this.getUserInfo();
  }

getUserInfo(){
this.userService.getUserInfo().subscribe({
  next:(val:any)=>{
    console.log("User for Leave", val)
    this.getLeave(val)
  },
  error:(err:any)=>{
    console.log("Error", err)
  }
})
}

getLeave(leave:any){
  this.leaveService.getLeaveByDepartment(leave.department).subscribe({
    next:(val:any)=>{
      if (Array.isArray(val)) {
        // Format the date before assigning it to the dataSource
        val.forEach((item: any) => {
          item.dateSubmitted = this.datePipe.transform(item.dateSubmitted, 'MMMM dd, yyyy');
          item.leaveStartDate = this.datePipe.transform(item.leaveStartDate, 'MMMM dd, yyyy');
          item.leaveEndDate = this.datePipe.transform(item.leaveEndDate, 'MMMM dd, yyyy');
          // Repeat this for other date fields if needed
        });

        this.requestedLeavesDataSource = new MatTableDataSource(val.filter(leave => leave.status === 'Requested'));
        this.approvedLeavesDataSource = new MatTableDataSource(val.filter(leave => leave.status === 'Approved'));
        this.deniedLeavesDataSource = new MatTableDataSource(val.filter(leave => leave.status === 'Denied'));
        this.cancelledLeavesDataSource = new MatTableDataSource(val.filter(leave => leave.status === 'Cancelled'));
        
        this.requestedLeavesDataSource.paginator = this.requestedPaginator;
          this.approvedLeavesDataSource.paginator = this.approvedPaginator;
          this.deniedLeavesDataSource.paginator = this.deniedPaginator;
          this.cancelledLeavesDataSource.paginator = this.cancelledPaginator;
          this.requestedLeavesDataSource.sort = this.requestedSort;
          this.approvedLeavesDataSource.sort = this.approvedSort;
          this.cancelledLeavesDataSource.sort = this.cancelledSort;
      
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
  const dialogRef = this.dialog.open(ManageLeaveStatusComponent, {
    width: '1000px',
    height: 'auto',
    maxHeight: '90vw',
    data:data,
  });
}
}
