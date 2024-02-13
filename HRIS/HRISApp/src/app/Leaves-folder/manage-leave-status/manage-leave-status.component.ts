import { Component, Inject } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { LeavesService } from '../../Services/leaves-service/leaves.service';
import { CoreService } from '../../Services/core-service/core.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-manage-leave-status',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './manage-leave-status.component.html',
  styleUrl: './manage-leave-status.component.css'
})
export class ManageLeaveStatusComponent {
  leavelist: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ManageLeaveStatusComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private leaveDetailsFb: FormBuilder,
    private leaveService: LeavesService,
    private coreService: CoreService,
    private datePipe : DatePipe
  ) {
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
      resOfCancel: { value: null, disabled: true } // Initially disable the field
    });

    // Subscribe to changes in the status field
    this.leavelist.get('status')?.valueChanges.subscribe((status: string) => {
      if (status === 'Denied') {
        this.leavelist.get('resOfCancel')?.enable(); // Enable the field if status is 'Denied'
      } else {
        this.leavelist.get('resOfCancel')?.disable(); // Disable the field otherwise
      }
    });
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
