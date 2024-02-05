import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { RequirementService } from '../../Services/requirement-services/requirement.service';

@Component({
  selector: 'app-edit-requirement',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './edit-requirement.component.html',
  styleUrl: './edit-requirement.component.css'
})
export class EditRequirementComponent {

  requirementDetails: FormGroup;

  constructor(
    private reqDetailsFb: FormBuilder,
    private requirementService: RequirementService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EditRequirementComponent>,
    private cdr: ChangeDetectorRef,) {

    this.requirementDetails = this.reqDetailsFb.group({
      id:[''],
      polygraph:  [{ value: '', disabled: false }],
      phyExam:  [{ value: '', disabled: false }],
      sssNo:  [{ value: '', disabled: false }],
      residentCert:  [{ value: '', disabled: false }],
      tor:  [{ value: '', disabled: false }],
      drvLicense:  [{ value: '', disabled: false }],
      empCert:  [{ value: '', disabled: false }],
      itr:  [{ value: '', disabled: false }],
      tinNo:  [{ value: '', disabled: false }],
      philhealthNo:  [{ value: '', disabled: false }],
      pagibigNo:  [{ value: '', disabled: false }],
      nbi:  [{ value: '', disabled: false }],
      marriageCert: [{ value: '', disabled: false }],
      pic:  [{ value: '', disabled: false }],
      clearance:  [{ value: '', disabled: false }],
      isPolygraph: new FormControl(true),
      isPhyExam: new FormControl(true),
      isSSSNo: new FormControl(true),
      isResidentCert: new FormControl(true),
      isTOR: new FormControl(true),
      isDrvLicense: new FormControl(true),
      isEmpCert: new FormControl(true),
      isITR: new FormControl(true),
      isTinNo: new FormControl(true),
      isPhilhealthNo: new FormControl(true),
      isPic: new FormControl(true),
      isPagibig: new FormControl(true),
      isNbi: new FormControl(true),
      isMarriageCert: new FormControl(true),
      isClearance: new FormControl(true),
      employeeId: [''],
     
    })
    this.setupCheckboxControl('isPolygraph', 'polygraph');
    this.setupCheckboxControl('isPhyExam', 'phyExam');
    this.setupCheckboxControl('isSSSNo', 'sssNo');
    this.setupCheckboxControl('isResidentCert', 'residentCert');
    this.setupCheckboxControl('isDrvLicense', 'drvLicense');
    this.setupCheckboxControl('isEmpCert', 'empCert');
    this.setupCheckboxControl('isITR', 'itr');
    this.setupCheckboxControl('isTinNo', 'tinNo');
    this.setupCheckboxControl('isPagibig', 'pagibigNo');
    this.setupCheckboxControl('isNbi', 'nbi');
    this.setupCheckboxControl('isPic', 'pic');
    this.setupCheckboxControl('isClearance', 'clearance');
    this.setupCheckboxControl('isTOR', 'tor');
    this.setupCheckboxControl('isPhilhealthNo', 'philhealthNo');
    this.setupCheckboxControl('isMarriageCert', 'marriageCert');

    
  }
  ngOnInit(): void {
  console.log("Data Patching", this.data)
  this.requirementDetails.patchValue(this.data)
  this.setupInitialState();
  }
  private setupCheckboxControl(checkboxName: string, inputName: string): void {
    const checkboxControl = this.requirementDetails.get(checkboxName)!;
    const inputControl = this.requirementDetails.get(inputName)!;
  
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
  
      this.requirementDetails.patchValue({
        ...defaultValues,
        employeeId: this.data.selectedEmployeeId,
      });
  
      // Set initial state for each checkbox
      Object.keys(defaultValues).forEach((checkboxName) => {
        const inputName = checkboxName.toLowerCase();
        const checkboxControl = this.requirementDetails.get(checkboxName)!;
        const inputControl = this.requirementDetails.get(inputName)!;
  
        if (!checkboxControl.value) {
          inputControl.disable();
        }
      });
    }

  onFormSubmit() {

    Object.keys(this.requirementDetails.controls).forEach(controlName => {
      const control = this.requirementDetails.get(controlName);
      if (control && control.disabled) {
        control.enable();
      }
    });

    if (this.requirementDetails.valid) {
      console.log('Data:', this.data.id);
      this.requirementService
        .updateRequirement(this.data.id, this.requirementDetails.value)
        .subscribe({
          next: () => {
            console.log('Update successful');
            const updatedData = this.requirementDetails.value;
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
