import { Component } from '@angular/core';
import { MaterialModule } from '../material/material.module';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { AddEditbookComponent } from '../add-editbook/add-editbook.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { EmployeeDetailsService } from '../Services/employee-details-service/employee-details.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [
    MaterialModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule
  ],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css'
})
export class BookComponent {

  constructor(public dialog: MatDialog, private bookService : EmployeeDetailsService){}

  displayedColumns: string[] = ['bookName', 'author', 'actions'];
 
  dataSource!: MatTableDataSource<any>;

  
  ngOnInit(): void {
   
    this.getBookDetails();
  }
  // openAddEditDialog(): void {
  //   console.log('Opening AddEditDialog...');
  //   const dialogRef = this.dialog.open(AddEdit201FileComponent);

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddEditbookComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openEditForm(data: any) {
    const dialogRef = this.dialog.open(AddEditbookComponent, {
      data: data,  // Pass the data to the dialog
    });
  
    dialogRef.afterClosed().subscribe({
      next: (bookDetails) => {
        if (bookDetails) {
          this.getBookDetails();
        }
      },
    });
  }

  getBookDetails(){
    this.bookService.getBooks().subscribe({
      next: (bookDetails) => {
        console.log('Book Details Data:', bookDetails);
        if (Array.isArray(bookDetails)) {
          this.dataSource = new MatTableDataSource(bookDetails);
        } else {
          console.error('Book Details Data is not an array.');
        }
      },
      error: (error) => {
        console.error('Error fetching Employee Details Data:', error);
      }
    });
  }

  
}
