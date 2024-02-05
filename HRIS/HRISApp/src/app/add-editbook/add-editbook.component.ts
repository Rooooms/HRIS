import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeDetailsService } from '../Services/employee-details-service/employee-details.service';
import { MaterialModule } from '../material/material.module';

@Component({
  selector: 'app-add-editbook',
  standalone: true,
  imports: [
    MaterialModule
  ],
  templateUrl: './add-editbook.component.html',
  styleUrl: './add-editbook.component.css'
})
export class AddEditbookComponent implements OnInit {
bookDetails! : FormGroup;
constructor(public dialogRef: MatDialogRef<AddEditbookComponent>,
  @Inject(MAT_DIALOG_DATA) public data: any, // Keep it as any for now
  private bookDetailsFb: FormBuilder, private bookService: EmployeeDetailsService,
  private cdr: ChangeDetectorRef
){

  

  this.bookDetails = this.bookDetailsFb.group({
    id: [''],
    bookName: [''],
    author : [''],
  })
}

ngOnInit(): void {

  console.log("Data Patching", this.data)
  
  this.bookDetails.patchValue(this.data)
}

onFormSubmit() {
  if (this.bookDetails.valid) {
    if (this.data) {
      console.log('Data:', this.data.id);
      this.bookService
        .updateBooks(this.data.id, this.bookDetails.value)
        .subscribe({
          next: (val: any) => {
            console.log('Updated data:', this.data);
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          },
        });
    } else {
   
      this.bookService.addBook(this.bookDetails.value).subscribe({
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
}
}
