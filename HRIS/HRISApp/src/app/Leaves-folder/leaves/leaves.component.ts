import { Component } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { LeavesService } from '../../Services/leaves-service/leaves.service';
import { CoreService } from '../../Services/core-service/core.service';

@Component({
  selector: 'app-leaves',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './leaves.component.html',
  styleUrl: './leaves.component.css'
})
export class LeavesComponent {

  leavelist : FormGroup

  constructor(private leaveService : LeavesService, private leavelistFb :FormBuilder, private coreService : CoreService){
    this.leavelist = this.leavelistFb.group({
      
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
      status: 'Requested',
      reason: '',
      credit: 0,
      resOfCancel: null
  })
  }


  onformSubmit(){
    if(this.leavelist.valid){
      this.leaveService.addLeaves(this.leavelist.value).subscribe({
        next: (val: any) => {
            if (val) {
                console.log('Leave', val);
                this.coreService.openSnackBar('Request Successfully');
            } else {
                console.error('Invalid response from the server.');
            }
        },
        error: (err: any) => {
            console.error('Error', err);
        }
    });
    }
  }
}
