import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmploymentBgService } from '../../Services/employment-bg-service/employment-bg.service';
import { FormBuilder, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-employment-background',
  standalone: true,
  templateUrl: './employment-background.component.html',
  styleUrls: ['./employment-background.component.css'],
  imports: [
    MaterialModule,
    CommonModule
  ],
})
export class EmploymentBackgroundComponent {
  // empContainers: any[] = [{}];

  // addAnotherField() {
  //   this.empContainers.push({});
  // }

  employmentBgDetails: FormGroup;

  constructor(
    private empDetailsFb: FormBuilder,
    private employmentBgService: EmploymentBgService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EmploymentBackgroundComponent>,
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
    console.log('Data Patching', this.data);
    this.employmentBgDetails.patchValue({ employeeId: this.data.selectedEmployeeId });
  }

  onFormSubmit() {
    const selectedEmployeeId = this.data.selectedEmployeeId;
    this.employmentBgService.addEmploymentBg(selectedEmployeeId, this.employmentBgDetails.value).subscribe({
      next: (val: any) => {
        console.log('Add successful:', val);
        this.dialogRef.close(true);
      },
      error: (err: any) => {
        console.error('Add error:', err);
      },
    });
  }
}
