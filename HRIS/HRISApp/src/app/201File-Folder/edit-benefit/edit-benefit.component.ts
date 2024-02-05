import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BenefitService } from '../../Services/benefit-service/benefit.service';

@Component({
  selector: 'app-edit-benefit',
  standalone: true,
  imports: [
    MaterialModule,
  ],
  templateUrl: './edit-benefit.component.html',
  styleUrl: './edit-benefit.component.css'
})
export class EditBenefitComponent {

  benefitDetails!: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditBenefitComponent>,
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

    this.benefitDetails.patchValue(this.data);
  }

  onFormSubmit() {
    this.benefitService
        .updateBenefits(this.data.id, this.benefitDetails.value)
        .subscribe({
          next: (val: any) => {
            console.log('Updated data:', this.data);
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
  }
}
