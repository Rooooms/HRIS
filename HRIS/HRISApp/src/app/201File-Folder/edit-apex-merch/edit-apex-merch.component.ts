import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ApexMerchService } from '../../Services/Apex-Merch-Services/apex-merch.service';
import { MaterialModule } from '../../material/material.module';

@Component({
  selector: 'app-edit-apex-merch',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './edit-apex-merch.component.html',
  styleUrl: './edit-apex-merch.component.css'
})
export class EditApexMerchComponent implements OnInit {
  apexMerchDetails!: FormGroup;
  constructor(public dialogRef: MatDialogRef<EditApexMerchComponent>,
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
    console.log("Data Patching", this.data)
    this.apexMerchDetails.patchValue(this.data)
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
      const defaultValues = this.data
      console.log(defaultValues)
  
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

      Object.keys(this.apexMerchDetails.controls).forEach(controlName => {
        const control = this.apexMerchDetails.get(controlName);
        if (control && control.disabled) {
          control.enable();
        }
      });
  
      if (this.apexMerchDetails.valid) {
        console.log('Data:', this.data.id);
        this.apexMerchService
          .updateApexMerch(this.data.id, this.apexMerchDetails.value)
          .subscribe({
            next: () => {
              console.log('Update successful');
              const updatedData = this.apexMerchDetails.value;
              console.log('Updated data:', updatedData);
              this.dialogRef.close(true);
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      }
       // Disable the controls again after submitting if needed
       this.setupInitialState();
    }
}
