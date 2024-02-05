import { Component, Inject, ViewChild, OnInit, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeDetailsService } from '../../Services/employee-details-service/employee-details.service';
import { EmploymentComponent } from '../employment/employment.component';
import { MaterialModule } from '../../material/material.module';
import { DataPersonalComponent } from '../data-personal/data-personal.component';
import * as flatted from 'flatted';
import { EducationComponent } from '../education/education.component';
import { EducationalBgService } from '../../Services/education-service/educational-bg.service';
import { CoreService } from '../../Services/core-service/core.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-edit201file',
  standalone: true,
  imports: [
    DataPersonalComponent,
    MaterialModule,
    EmploymentComponent,
    EducationComponent
  ],
  templateUrl: './edit201file.component.html',
  styleUrl: './edit201file.component.css'
})
export class Edit201fileComponent implements OnInit {  
  employeeDetails: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<Edit201fileComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private empDetailsFb: FormBuilder,
    private employeeDetailsService: EmployeeDetailsService,
    private cdr: ChangeDetectorRef,
    private coreService: CoreService,
    private datePipe :DatePipe
    
  ) {
    this.employeeDetails = this.empDetailsFb.group({
        id: [''],
        companyName: [''],
        companyId: [''],
        branch:[''], 
        department: [''],
        warehouseNo: [''],
        employmentType: [''],
        employmentRole: [''],
        position: [''],
        roleLevel: [''],
        promoId: [''],
        fName: [''],
        mName: [''],
        lName: [''],
        ne: [''],
        birthDate: [null],
        empDate: [null],
        desigDate: [null],
        sepDate: [null],
        salesDate: [null],
        evalDate: [null],
        isEvaluation: true,
        employeeStatus: [''],
        ccNo: [''],
        statusDesc: [''],
        workDays: [''],
        plateNo: [''],
        offIn: [''],
        offOut: [''],
        baseFlag: [''],
        effDate: [null],
        adjustment: [''],
        region: [''],
        checkDGT: [''],
        noOfDays: 0,
        payType: [''],
        schedule: [''],
        rate: [''],
        userLevel: [''],
        pob: [''],
        civilStat: [''],
        sex: [''],
        citizenship: [''],
        religion: [''],
        email: [''],
        cityAddress: [''],
        provAddress: [''],
        mobileNum: [''],
        telNum: [''],
        spouseName: [''],
        spouseAge: [''],
        spouseOccupation: [''],
        childName: [''],
        childAge: [''],
        fatherName: [''],
        fatherAge: [''],
        fatherOccupation: [''],
        motherName: [''],
        motherAge: [''],
        motherOccupation: [''],
        language: [''],
        medical: [''],
        medicalPurpose: [''],
        medicalResult: [''],
        majorIllness: [''],
        emerPerson: [''],
        emerPersonNumber: [''],
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
        isExcludeSmanped: false,
    });

  }

 private formatDate(date: Date | null): string | null {
  if (date instanceof Date) {
    const year = date.getUTCFullYear();
    const month = date.getUTCMonth() + 1; // Months are zero-based
    const day = date.getUTCDate();
    const hours = date.getUTCHours();
    const minutes = date.getUTCMinutes();
    const seconds = date.getUTCSeconds();
    const milliseconds = date.getUTCMilliseconds();

    const formattedDate = `${year}-${this.pad(month)}-${this.pad(day)}T${this.pad(hours)}:${this.pad(minutes)}:${this.pad(seconds)}.${milliseconds}`;
    
    return formattedDate;
  } else {
    return null;
  }
}

private pad(value: number): string {
  return value < 10 ? '0' + value : value.toString();
}
  ngOnInit(): void {
    console.log('ngOnInit is called');
    console.log('data patching', this.data);
    this.cdr.detectChanges();
    this.employeeDetails.patchValue(this.data);
    console.log('Form Group:', this.employeeDetails);
    
  }
  onFormSubmit() {
    if (this.employeeDetails.valid) {
      const serializedData = this.serializeFormData(this.employeeDetails.value);
      console.log('Request Payload:', serializedData);
      this.employeeDetailsService.updateEmployeeDetails(this.data.id, serializedData).subscribe({
        next: (val: any) => {
          this.coreService.openSnackBar("Update Successfully")
          this.dialogRef.close(true);
          this.refreshPage(); 
        },
        error: (err: any) => {
          console.error('Error updating form:', err);
        },
      });
    } else {
      console.log('Form is invalid. Cannot submit.');
    }
    
  }
  private serializeFormData(formData: any): any {
    const serializedData: any = {};

    Object.keys(formData).forEach((key) => {
      const value = formData[key];

      if (key === 'effDate') {
        serializedData[key] = this.formatDate(value);
      } else if (value instanceof Date) {
        serializedData[key] = this.formatDate(value);
      } else if (value instanceof FormGroup) {
        serializedData[key] = this.serializeFormData(value.value);
      } else {
        serializedData[key] = value;
      }
    });

    return serializedData;
  }
  
  
  
  
  
  refreshPage() {
    // You can use window.location.reload() to refresh the page
    window.location.reload();
  }
}
