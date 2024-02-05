import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EducationalBgService } from '../../Services/education-service/educational-bg.service';
import { EducationComponent } from '../education/education.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-educational-bg',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './edit-educational-bg.component.html',
  styleUrl: './edit-educational-bg.component.css'
})
export class EditEducationalBgComponent implements OnInit {

  educationalDetails: FormGroup;

  constructor(
    private empDetailsFb: FormBuilder,
    private educationalBGService: EducationalBgService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EditEducationalBgComponent>,
    private cdr: ChangeDetectorRef,) {
    this.educationalDetails = this.empDetailsFb.group({
      id: [''],
      degree: [''],
      gradSchool: [''],
      license: [''],
      elemInstitute: [''],
      elemLoc: [''],
      elemDateInc: [''],
      elemAchievement: [''],
      hsInstitute: [''],
      hsLoc: [''],
      hsDateInc: [''],
      hsAchievement: [''],
      terInstitute: [''],
      terLoc: [''],
      terDateInc: [''],
      terAchievement: [''],
      employeeId: [''],
    })
  }
  ngOnInit(): void {
  console.log("Data Patching", this.data)
  this.educationalDetails.patchValue(this.data)
  }

  onFormSubmit() {
    if (this.educationalDetails.valid) {
      console.log('Data:', this.data.id);
      this.educationalBGService
        .updateEducationalBG(this.data.id, this.educationalDetails.value)
        .subscribe({
          next: () => {
            console.log('Update successful');
            const updatedData = this.educationalDetails.value;
            console.log('Updated data:', updatedData);
            
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
    }
  }


  
}
