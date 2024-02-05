import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EmploymentBgService } from '../../Services/employment-bg-service/employment-bg.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MaterialModule } from '../../material/material.module';

@Component({
  selector: 'app-edit-employent-bg',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './edit-employent-bg.component.html',
  styleUrl: './edit-employent-bg.component.css'
})
export class EditEmployentBgComponent implements OnInit {

  employmentBgDetails: FormGroup;

  constructor(
    private empDetailsFb: FormBuilder,
    private employmentBgService: EmploymentBgService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EditEmployentBgComponent>,
    private cdr: ChangeDetectorRef,) {

    this.employmentBgDetails = this.empDetailsFb.group({
      id: [''],
      prevCompany: [''],
      natOfBusiness: [''],
      prevPosition: [''],
      prevSalary: 0,
      incDate: [''],
      jobDescription: [''],
      reasOfLeave: [''],
      contribution: [''],
      employeeId: [''],
     
    })
  }
  ngOnInit(): void {
  console.log("Data Patching", this.data)
  this.employmentBgDetails.patchValue(this.data)
  }

  onFormSubmit() {
    if (this.employmentBgDetails.valid) {
      console.log('Data:', this.data.id);
      this.employmentBgService
        .updateEmploymentBg(this.data.id, this.employmentBgDetails.value)
        .subscribe({
          next: () => {
            console.log('Update successful');
            const updatedData = this.employmentBgDetails.value;
            console.log('Updated data:', updatedData);
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
    }
  }

}
