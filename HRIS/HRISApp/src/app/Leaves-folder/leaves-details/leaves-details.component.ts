import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { LeavesService } from '../../Services/leaves-service/leaves.service';
import { CoreService } from '../../Services/core-service/core.service';
import { DatePipe } from '@angular/common';
import { MaterialModule } from '../../material/material.module';

@Component({
  selector: 'app-leaves-details',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './leaves-details.component.html',
  styleUrl: './leaves-details.component.css'
})
export class LeavesDetailsComponent implements OnInit{

leavelist:FormGroup

  constructor(
    public dialogRef: MatDialogRef<LeavesDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private leaveDetailsFb: FormBuilder,
    private leaveService: LeavesService,
    private coreService: CoreService,
    private datePipe :DatePipe
  )
  {
    this.leavelist = this.leaveDetailsFb.group({
      
      id: '',
      userId: '',
      employeeId: '',
      employeeName: '',
      employeeNumber: 0,
      userLevel: 0,
      company: '',
      branch: '',
      department: '',
      leaveStartDate: null,
      leaveEndDate: null,
      dateSubmitted: null,
      status: '',
      reason: '',
      credit: 0,
      resOfCancel: null
      
    
  })
  }
  ngOnInit(): void {
    this.leavelist.patchValue(this.data);

    const leaveStartDate = this.data.leaveStartDate;
    const leaveEndDate = this.data.leaveEndDate;

    // Convert date strings to valid date objects
    const formattedStartDate = this.datePipe.transform(leaveStartDate, 'yyyy-MM-dd');
    const formattedEndDate = this.datePipe.transform(leaveEndDate, 'yyyy-MM-dd');

    // Patching values to the date range picker form controls
    this.leavelist.get('leaveStartDate')?.setValue(formattedStartDate);
    this.leavelist.get('leaveEndDate')?.setValue(formattedEndDate);
  }


  onFormSubmit() {
    if (this.leavelist.valid) {
  
    // Inside your Angular component where you call the service
this.leaveService.updateLeaves(this.data.id, this.leavelist.value).subscribe({
  next: (val: any) => {
    console.log('update', val);
    this.coreService.openSnackBar('Update Successfully');
    this.dialogRef.close(true);
  },
  error: (err: any) => {
    console.error('Error updating form:', err);
  },
});
}
}
  
refreshPage() {
  // You can use window.location.reload() to refresh the page
  window.location.reload();
}

}
