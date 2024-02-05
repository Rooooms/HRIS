import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-data-personal',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './data-personal.component.html',
  styleUrl: './data-personal.component.css'
})
export class DataPersonalComponent {

  @Output() personalDataSubmitted: EventEmitter<any> = new EventEmitter<any>();
  personalData: FormGroup;
  @Input() data: any = null;
 
  constructor(private fb: FormBuilder){
    this.personalData = this.fb.group({
        id:'',
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
        emerPersonNumber: ""
        
  });
}
onPersonalDetails(personalData: any) {
  // Handle general info form submission logic if needed
  console.log('Personal Data Submitted:', personalData);
}

getFormData() {
  return this.personalData.value;
}

onSubmit() {
  if (this.personalData.valid) {
    console.log('Employment Form Value:', this.personalData.value);
    this.personalDataSubmitted.emit(this.personalData.value);
  }
} 
}
