import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { PaymastComponent } from '../paymast/paymast.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PaymastService } from '../../Services/paymast-services/paymast.service';

@Component({
  selector: 'app-edit-paymast',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './edit-paymast.component.html',
  styleUrl: './edit-paymast.component.css'
})
export class EditPaymastComponent {

  paymastDetails : FormGroup;

    constructor(
      private paymastFb: FormBuilder,
    private paymastService: PaymastService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<PaymastComponent>,
    private cdr: ChangeDetectorRef,
    ){
      
      this.paymastDetails = this.paymastFb.group({
        id: [''],
        employeeId : [''],
        fixTaxRate: 0,
        baseMonthly: 0,
        base15th: 0,
        baseMonthEnd: 0,
        colaMonthly: 0,
        cola15th: 0,
        colaMonthEnd: 0,
        empShare: 0,
        medAllowance: 0,
        dailyShare: 0,
        depName: [''],
        depBirthday: [''],
        ctcNo: [''],
        dateIssue: [''],
        rateType: [''],
        placeIssue: [''],
        payslipPinNo: [''],
        excPayrollProcess: true
      })
    }
  ngOnInit(): void {
  console.log("Data Patching", this.data)
  this.paymastDetails.patchValue(this.data)
  }

  onFormSubmit() {
    if (this.paymastDetails.valid) {
      console.log('Data:', this.data.id);
      this.paymastService
        .updatePaymast(this.data.id, this.paymastDetails.value)
        .subscribe({
          next: () => {
            console.log('Update successful');
            const updatedData = this.paymastDetails.value;
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
