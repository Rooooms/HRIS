import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PaymastService } from '../../Services/paymast-services/paymast.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-paymast',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './paymast.component.html',
  styleUrl: './paymast.component.css'
})
export class PaymastComponent implements OnInit {

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
    console.log('Data Patching', this.data);
    this.paymastDetails.patchValue({ employeeId: this.data.selectedEmployeeId });
  }

  onFormSubmit() {
    const selectedEmployeeId = this.data.selectedEmployeeId;
    this.paymastService.addPaymast(selectedEmployeeId, this.paymastDetails.value).subscribe({
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
