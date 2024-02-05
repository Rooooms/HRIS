import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employment-details',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './employment-details.component.html',
  styleUrl: './employment-details.component.css'
})
export class EmploymentDetailsComponent {
  @Output() employeeDetailsSubmitted: EventEmitter<any> = new EventEmitter<any>();
  employeeDetails: FormGroup;
  @Input() data: any = null;
  constructor(private fb: FormBuilder){
    this.employeeDetails = this.fb.group({
      employeeStatus: "",
        ccNo: "",
        statusDesc: "",
        workDays: "",
        plateNo: "",
        offIn: "",
        offOut: "",
        baseFlag: "",
        effDate: "",
        adjustment: "",
        region: "",
        checkDGT: "",
        noOfDays: 0,
        payType: "",
        schedule: "",
        rate: "",
        userLevel: "",
      
});
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
