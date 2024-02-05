import { Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-employee-details',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './employee-details.component.html',
  styleUrl: './employee-details.component.css'
})
export class EmployeeDetailsComponent implements OnInit {
  employeeDetails: FormGroup;
  employeeData: any;  // Declare property to hold data

  constructor(private fb: FormBuilder, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.employeeDetails = this.fb.group({
      id: [''],
      fName: [''],
      mName: [''],
      lName: [''],
      employeeNumber: [''],
      ccNo: [''],
    });
  }

  ngOnInit(): void {
    console.log('Data Patching', this.data);
    this.employeeData = this.data;  // Assign data to the property
    this.employeeDetails.patchValue(this.data);
  }

}
