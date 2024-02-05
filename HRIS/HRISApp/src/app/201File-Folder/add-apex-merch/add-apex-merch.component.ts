import { Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ApexMerch } from '../../model/apex.merch.model';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ApexMerchService } from '../../Services/Apex-Merch-Services/apex-merch.service';

@Component({
  selector: 'app-add-apex-merch',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './add-apex-merch.component.html',
  styleUrl: './add-apex-merch.component.css'
})
export class AddApexMerchComponent implements OnInit{


  apexMerchDetails!: FormGroup;
  constructor(public dialogRef: MatDialogRef<AddApexMerchComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, // Keep it as any for now
    private apexMerchFb: FormBuilder, private apexMerchService: ApexMerchService,
    
  ) {
    this.apexMerchDetails = this.apexMerchFb.group({
      id : [''],
      employeeId : [''],
      isRAM: new FormControl(true),
      isMitra: new FormControl(true),
      isSevilla: new FormControl(true),
      isVar: new FormControl(true),
      isInfini: new FormControl(true),
      ramPercent: [{ value: '', disabled: false }],
      noOutlet: [{ value: 0, disabled: false }],
      sevPercent: [{ value: '', disabled: false }],
      varAmount: [{ value: '', disabled: false }],
      infiniAmount: [{ value: '', disabled: false }]
    })

    this.setupCheckboxControl('isRAM', 'ramPercent');
    this.setupCheckboxControl('isMitra', 'noOutlet');
    this.setupCheckboxControl('isSevilla', 'sevPercent');
    this.setupCheckboxControl('isVar', 'varAmount');
    this.setupCheckboxControl('isInfini', 'infiniAmount');
  }
  ngOnInit(): void {
    console.log('Data Patching', this.data);
    this.apexMerchDetails.patchValue({ employeeId: this.data });

    this.setupInitialState();
  }

  private setupCheckboxControl(checkboxName: string, inputName: string): void {
    const checkboxControl = this.apexMerchDetails.get(checkboxName)!;
    const inputControl = this.apexMerchDetails.get(inputName)!;
  
    checkboxControl.valueChanges.subscribe((isChecked: boolean) => {
      if (!isChecked) {
        inputControl.setValue(''); // Set input value to null when checkbox is unchecked
      }
      isChecked ? inputControl.enable() : inputControl.disable();
    });
  }

  private setupInitialState(): void {
    const defaultValues = {
      isRAM: false,
      isMitra: false,
      isSevilla: false,
      isVar: false,
      isInfini: false,
      
    };

    this.apexMerchDetails.patchValue({
      ...defaultValues,
      employeeId: this.data.selectedEmployeeId,
    });

    // Set initial state for each checkbox
    Object.keys(defaultValues).forEach((checkboxName) => {
      const inputName = checkboxName.toLowerCase();
      const checkboxControl = this.apexMerchDetails.get(checkboxName)!;
      const inputControl = this.apexMerchDetails.get(inputName)!;

      if (!checkboxControl.value) {
        inputControl.disable();
      }
    });
  }
  onFormSubmit() {
    const selectedEmployeeId = this.data.selectedEmployeeId;
  
    // Enable all disabled controls before submitting
    Object.keys(this.apexMerchDetails.controls).forEach(controlName => {
      const control = this.apexMerchDetails.get(controlName);
      if (control && control.disabled) {
        control.enable();
      }
    });
  
    this.apexMerchService.addApexMerch(selectedEmployeeId, this.apexMerchDetails.value).subscribe({
      next: (val: any) => {
        console.log('Add successful:', val);
        this.dialogRef.close(true);
      },
      error: (err: any) => {
        console.error('Add error:', err);
      },
    });
  
    // Disable the controls again after submitting if needed
    this.setupInitialState();
  }
}
