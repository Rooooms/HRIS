import { Component, ElementRef, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { BankRemitDetailsComponent } from '../bank-remit-details/bank-remit-details.component';
import { EmploymentDetailsComponent } from '../employment-details/employment-details.component';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { CommonModule } from '@angular/common';




@Component({
  selector: 'app-employment',
  standalone: true,
  imports: [
    MaterialModule,
    BankRemitDetailsComponent,
    EmploymentDetailsComponent,
    CommonModule
    
  ],
  templateUrl: './employment.component.html',
  styleUrl: './employment.component.css'
})
export class EmploymentComponent {
  @Output() employeeDetailsSubmitted: EventEmitter<any> = new EventEmitter<any>();
  employeeDetails: FormGroup;
  @Input() data: any = null;
 
  constructor(private fb: FormBuilder){
    this.employeeDetails = this.fb.group({
      id: [''],
      companyName: ['', Validators.required],
      branch:['', Validators.required], 
      department: ['', Validators.required],
      warehouseNo: ['', Validators.required],
      employmentType: [''],
      employmentRole: ['', Validators.required],
      position: ['', Validators.required],
      roleLevel: [''],
      promoId: [''],
      fName: ['', Validators.required],
      mName: ['', Validators.required],
      lName: ['', Validators.required],
      ne: [''],
      birthDate: ['', Validators.required],
      empDate: [null],
      desigDate: [null],
      sepDate: [null],
      salesDate: [null],
      evalDate: [null],
      isEvaluation: true,
      employeeStatus: ['', Validators.required],
      ccNo: ['', Validators.required],
      statusDesc: "",
      workDays: "",
      plateNo: "",
      offIn: "",
      offOut: "",
      baseFlag: "",
      effDate: [null],
      adjustment: "",
      region: "",
      checkDGT: "",
      noOfDays: 0,
      payType: ['', Validators.required],
      schedule: "",
      rate: ['', Validators.required],
      userLevel: [''],
      bankAcc: "",
      bankAcc2: "",
      bankName: "",
      bankName2: "",
      accType: "",
      sssNo: "",
      exemption: "",
      tinNo: "",
      group: "",
      pagibiNo: "",
      payper: "",
      philhealth: "",
      isPayroll: false,
      isNoTax: false,
      isNoSSS: false,
      isNoPremium: false,
      isExcludeSmanped: false
        
  });
}
onEmployeeDetails(employmentData: any) {
  // Handle general info form submission logic if needed
  console.log('Employment Data Submitted:', employmentData);
}

getFormData() {
  return this.employeeDetails.value;
}

onSubmit() {
  if (this.employeeDetails.valid) {
    console.log('Employment Form Value:', this.employeeDetails.value);
    this.employeeDetailsSubmitted.emit(this.employeeDetails.value);
  }
} 
}