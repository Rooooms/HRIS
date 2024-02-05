import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { BenefitService } from '../../Services/benefit-service/benefit.service';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';



@Component({
  selector: 'app-benefit',
  standalone: true,
  imports: [
    MaterialModule,
    MatButtonModule, MatTableModule, CommonModule

  ],
  templateUrl: './benefit.component.html',
  styleUrl: './benefit.component.css'
})
export class BenefitComponent implements OnInit {
  benefitDetails!: FormGroup;
  constructor(public dialogRef: MatDialogRef<BenefitComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, // Keep it as any for now
    private benefitFb: FormBuilder, private benefitService: BenefitService,
    private cdr: ChangeDetectorRef
  ) {
    this.benefitDetails = this.benefitFb.group({
      id: [''],
      employeeId: [''],
      benefitName: [''],
      benefitAmount: 0,
      dateGiven: ['']
    })
  }

  ngOnInit(): void {

    console.log("Data Patching", this.data)

    this.benefitDetails.patchValue({ employeeId: this.data.selectedEmployeeId });
  }

  onFormSubmit() {
    const selectedEmployeeId = this.data.selectedEmployeeId;
    this.benefitService.addBenefits(selectedEmployeeId, this.benefitDetails.value).subscribe({
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


