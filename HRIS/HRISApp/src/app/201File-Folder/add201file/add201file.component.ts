import { Component, Inject, ViewChild } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { DataPersonalComponent } from '../data-personal/data-personal.component';
import { EmploymentComponent } from '../employment/employment.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeDetailsService } from '../../Services/employee-details-service/employee-details.service';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-add201file',
  standalone: true,
  imports: [
    DataPersonalComponent,
    MaterialModule,
    EmploymentComponent
  ],
  templateUrl: './add201file.component.html',
  styleUrls: ['./add201file.component.css'] 
})
export class Add201fileComponent {
  @ViewChild(EmploymentComponent) employmentComponent!: EmploymentComponent;
  @ViewChild(DataPersonalComponent) datapersonalComponent!: DataPersonalComponent;
  employeeDetails : FormGroup

  constructor(
    public dialogRef: MatDialogRef<Add201fileComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EmployeeListComponent,
    private empDetailsFb: FormBuilder,
    private employeeDetailsService : EmployeeDetailsService
  ) {
    this.employeeDetails = this.empDetailsFb.group({
      id: [''],
      companyName: [''],
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
      birthDate: [''],
      empDate: [null],
      desigDate: [null],
      sepDate: [null],
      salesDate: [null],
      evalDate: [null],
      isEvaluation: true,
      employeeStatus: [''],
      ccNo: [''],
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
      payType: [''],
      schedule: "",
      rate: [''],
      userLevel: [''],
        pob: "",
        civilStat: "",
        sex: "",
        citizenship: "",
        religion: "",
        email: "",
        cityAddress: "",
        provAddress: "",
        mobileNum: "",
        telNum: "",
        spouseName: "",
        spouseAge: "",
        spouseOccupation: "",
        childName: "",
        childAge: "",
        fatherName: "",
        fatherAge: "",
        fatherOccupation: "",
        motherName: "",
        motherAge: "",
        motherOccupation: "",
        language: "",
        medical: "",
        medicalPurpose: "",
        medicalResult: "",
        majorIllness: "",
        emerPerson: "",
        emerPersonNumber: "",
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
 onPersonalDetails(personalData: any) {
  // Handle general info form submission logic if needed
  console.log('Employment Data Submitted:', personalData);
}

      
       
        
       
 onFormSubmit() {
  if (this.employeeDetails.valid && this.employmentComponent) {
    const employmentData = this.employmentComponent.getFormData();
    const personalData = this.datapersonalComponent.getFormData();
    

    const formData = {
      ...this.employeeDetails.value,
      ...employmentData,
      ...personalData,
      
    };

    console.log('Form Data:', formData);

    this.employeeDetailsService.addEmployeeDetails(formData).subscribe({
      next: (val: any) => {
        console.log('Form submitted successfully:', val);
        this.dialogRef.close(true);
        // this.refreshPage(); 
      },
      error: (err: any) => {
        console.error('Error submitting form:', err);
        // You can add additional error handling logic here
      },
    });
  } else {
    console.log('Emp Details', this.employeeDetails)
    console.log('Form is invalid. Cannot submit.');
  }
}
// refreshPage() {
  
//   window.location.reload();
// }
}
