import { ChangeDetectorRef, Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EducationalBgService } from '../../Services/education-service/educational-bg.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-education',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './education.component.html',
  styleUrl: './education.component.css'
})
export class EducationComponent implements OnInit {
  educationalDetails: FormGroup;

  constructor(
    private empDetailsFb: FormBuilder,
    private educationalBGService: EducationalBgService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<EducationComponent>,
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
    console.log('Data Patching', this.data);
    this.educationalDetails.patchValue({ employeeId: this.data.selectedEmployeeId });
  }

  onFormSubmit() {
    const selectedEmployeeId = this.data.selectedEmployeeId;
    this.educationalBGService.addEducationalBG(selectedEmployeeId, this.educationalDetails.value).subscribe({
      next: (val: any) => {
        console.log('Add successful:', val);
        this.dialogRef.close(true);
      },
      error: (err: any) => {
        console.error('Add error:', err);
      },
    });
  }
}
