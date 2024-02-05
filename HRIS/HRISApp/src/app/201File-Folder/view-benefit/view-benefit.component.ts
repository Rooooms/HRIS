import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule } from '@angular/forms';
import { BenefitService } from '../../Services/benefit-service/benefit.service';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MaterialModule } from '../../material/material.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { EditBenefitComponent } from '../edit-benefit/edit-benefit.component';
import { EmployeeDetailsService } from '../../Services/employee-details-service/employee-details.service';

 interface Employee{
  fName :string
  lName : string
 }


@Component({
  selector: 'app-view-benefit',
  standalone: true,
  imports: [
    MaterialModule,
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
  ],
  templateUrl: './view-benefit.component.html',
  styleUrl: './view-benefit.component.css'
})
export class ViewBenefitComponent {
  benefitDetails:FormGroup

  constructor(
    private empDetailsFb: FormBuilder,
    private benefitService: BenefitService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ViewBenefitComponent>,
    private cdr: ChangeDetectorRef, private benefitFb:FormBuilder, public dialog: MatDialog,
    private employeeDetailsService:EmployeeDetailsService) {
      this.benefitDetails = this.benefitFb.group({
        id: [''],
        employeeId: [''],
        benefitName: [''],
        benefitAmount: 0,
        dateGiven: ['']
      })
  }
  displayedColumns: string[] = ['benefitName', 'benefitAmount', 'dateGiven', 'actions'];

  employee!: Employee;
  dataSource!: MatTableDataSource<any>;

  ngOnInit(): void {
    console.log("Data Patchingsss", this.data.selectedEmployeeId)
    const selectedId = this.data.selectedEmployeeId
    this.benefitDetails.patchValue({ employeeId: this.data.selectedEmployeeId });
    this.getEmployee(selectedId['employeeId']);
    this.getBenefitListByEmployeeId(selectedId);
  }

  getBenefitListByEmployeeId(selectedId : string){
    this.benefitService.getBenefitByEmployeeId(selectedId).subscribe({  
      next : (benefit)=>{
        this.dataSource = new MatTableDataSource(benefit);
      }
    })
  }

  getEmployee(selectedId : string){
    this.employeeDetailsService.getEmployeeById(selectedId).subscribe({
      next : (emp)=>{
        this.employee=emp
        console.log('Employee', this.employee)
      }
    })
  }

  deleteBenefit(id : string){
    const isConfirmed = window.confirm('Are you sure you want to delete this data?');
    this.benefitService.deleteBenefits(id).subscribe({
      next : (empDetails) =>{
        
      },
      error: console.log
    });
  }

  editBenefit(data:any){
    console.log('data', data);
    const dialogRef = this.dialog.open(EditBenefitComponent, {
    width: '1000px',
    height: 'auto',
    maxHeight: '90vw',  
    data: data,  // Pass the data to the dialog
  });
  }
}
