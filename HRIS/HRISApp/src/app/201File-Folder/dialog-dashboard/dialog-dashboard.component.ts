import { Component, Inject, OnInit } from '@angular/core';
import { MaterialModule } from '../../material/material.module';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { Edit201fileComponent } from '../edit201file/edit201file.component';
import { EducationComponent } from '../education/education.component';
import { EducationalBgService } from '../../Services/education-service/educational-bg.service';
import { CoreService } from '../../Services/core-service/core.service';
import { EditEducationalBgComponent } from '../edit-educational-bg/edit-educational-bg.component';
import { EmploymentBgService } from '../../Services/employment-bg-service/employment-bg.service';
import { EducationalBackground } from '../../model/educationalbg.model';
import { EmploymentBackground } from '../../model/employmentbg.model';
import { EmploymentBackgroundComponent } from '../employment-background/employment-background.component';
import { EditEmployentBgComponent } from '../edit-employent-bg/edit-employent-bg.component';
import { EmployeeDetailsComponent } from '../employee-details/employee-details.component';
import { RequirementService } from '../../Services/requirement-services/requirement.service';
import { Requirement } from '../../model/requirement.model';
import { RequirementsComponent } from '../requirements/requirements.component';
import { EditRequirementComponent } from '../edit-requirement/edit-requirement.component';
import { PaymastService } from '../../Services/paymast-services/paymast.service';
import { Paymast } from '../../model/paymast.model';
import { PaymastComponent } from '../paymast/paymast.component';
import { EditPaymastComponent } from '../edit-paymast/edit-paymast.component';
import { BenefitComponent } from '../benefit/benefit.component';
import { BenefitService } from '../../Services/benefit-service/benefit.service';
import { Benefit } from '../../model/benefit.model';
import { ViewBenefitComponent } from '../view-benefit/view-benefit.component';
import { AddApexMerchComponent } from '../add-apex-merch/add-apex-merch.component';
import { ApexMerchService } from '../../Services/Apex-Merch-Services/apex-merch.service';
import { ApexMerch } from '../../model/apex.merch.model';
import { EditApexMerchComponent } from '../edit-apex-merch/edit-apex-merch.component';


@Component({
  selector: 'app-dialog-dashboard',
  standalone: true,
  imports: [
    MaterialModule,

  ],
  templateUrl: './dialog-dashboard.component.html',
  styleUrl: './dialog-dashboard.component.css'
})
export class DialogDashboardComponent implements OnInit {
  educationalBackgroundList: EducationalBackground[] = [];
  employmentBackgroundList: EmploymentBackground[] = [];
  requirementList: Requirement[] = [];
  paymastList: Paymast[] = [];
  benefitList: Benefit[] = [];
  apexMerchList: ApexMerch[] = [];
  educationalbg = [];
  employmentbg = [];
  requirement = [];
  paymast = [];
  benefit = [];
  apexmerch = [];
  isMerchandiser: boolean = false;
  constructor(
    public dialogRef: MatDialogRef<DialogDashboardComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialog: MatDialog, private educationalBgService: EducationalBgService,
    private requirementService: RequirementService,
    private employmentBgService: EmploymentBgService,
    private paymastService: PaymastService,
    private benefitService: BenefitService,
    private coreService: CoreService,
    private apexMerchService: ApexMerchService
  ) { }

  ngOnInit() {
    this.educationalBgService.getEducationalBg().subscribe((educationalbg: any) => {
      this.educationalbg = educationalbg
      console.log('Educational Background are:', this.educationalbg)
    });
    this.employmentBgService.getEmploymentBg().subscribe((employmentbg: any) => {
      this.employmentbg = employmentbg
      console.log('Employment Background are:', this.employmentbg)
    });
    this.requirementService.getRequirement().subscribe((requirement: any) => {
      this.requirement = requirement
      console.log('Requirements are:', this.requirement)
    });
    this.paymastService.getPaymast().subscribe((paymast: any) => {
      this.paymast = paymast
      console.log('Paymast are:', this.paymast)
    });
    this.apexMerchService.getApexMerch().subscribe((apexmerch: any) => {
      this.apexmerch = apexmerch
      console.log('Apex Merch are:', this.apexmerch)
    });
    this.isMerchandiser = (this.data as any).employmentRole === 'Merchandiser';
    console.log('Employment Role:', this.data.employmentRole);

    
  }

  openadd201Form(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(Edit201fileComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  onEmployeeSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.educationalBgService.getEducationalBgByEmployeeId(selectedEmployeeId).subscribe(
      (data: EducationalBackground[]) => {
        console.log('dataaaa', data);

        // Assuming 'data' is an array of educational background objects
        const filteredEducationalBg = data.filter((edu: EducationalBackground) => edu.employeeId === selectedEmployeeId);
        console.log('Filtered Educational Background', filteredEducationalBg);

        if (filteredEducationalBg.length === 0) {
          this.openAddEducBgform(selectedEmployeeId);
        } else {
          this.coreService.openSnackBar('Employee already have Educational Background Data')
        }

        // Now 'filteredEducationalBg' contains only the entries with the selected employeeId
      }
    );

  }
  onEmployeeEditSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.educationalBgService.getEducationalBgByEmployeeId(selectedEmployeeId).subscribe(
      (data: EducationalBackground[]) => {
        console.log('dataaaa', data);

        // Assuming 'data' is an array of educational background objects
        const filteredEducationalBg = data.filter((edu: EducationalBackground) => edu.employeeId === selectedEmployeeId);
        console.log('Filtered Educational Background', filteredEducationalBg);

        if (filteredEducationalBg.length === 0) {
          this.coreService.openSnackBar("Employee doesn't have Educational Background Data")
        } else {
          const flattenedArray = filteredEducationalBg[0];
          this.openeducbgform(flattenedArray);
        }
      }
    );
  }

  onEmploymentbgSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.employmentBgService.getEmploymentBgByEmployeeId(selectedEmployeeId).subscribe(
      (data: EmploymentBackground[]) => {
        console.log('dataaaa', data);
        const filteredEmploymentBg = data.filter((emp: EmploymentBackground) => emp.employeeId === selectedEmployeeId);
        console.log('Filtered Employment Background', filteredEmploymentBg);
        if (filteredEmploymentBg.length === 0) {
          this.openAddEmpBgForm(selectedEmployeeId);
        } else {
          this.coreService.openSnackBar('Employee already have Educational Background Data')
        }
      }
    );

  }
  onEmploymentbgEditSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.employmentBgService.getEmploymentBgByEmployeeId(selectedEmployeeId).subscribe(
      (data: EmploymentBackground[]) => {
        console.log('dataaaa', data);

        const filteredEmploymentBg = data.filter((emp: EmploymentBackground) => emp.employeeId === selectedEmployeeId);
        console.log('Filtered Employment Background', filteredEmploymentBg);

        if (filteredEmploymentBg.length === 0) {
          this.coreService.openSnackBar("Employee doesn't have Employment Background Data")
        } else {
          const flattenedArray = filteredEmploymentBg[0];
          this.openEditEmpBg(flattenedArray);
        }
      }
    );

  }


  onRequirementSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.requirementService.getRequirementByEmployeeId(selectedEmployeeId).subscribe(
      (data: Requirement[]) => {
        console.log('dataaaa', data);
        const filteredRequirement = data.filter((req: Requirement) => req.employeeId === selectedEmployeeId);
        console.log('Filtered Employment Background', filteredRequirement);
        if (filteredRequirement.length === 0) {
          this.openAddRequirement(selectedEmployeeId);
        } else {
          this.coreService.openSnackBar('Employee already have Requirements')
        }
      }
    );

  }

  onRequirementEditSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.requirementService.getRequirementByEmployeeId(selectedEmployeeId).subscribe(
      (data: Requirement[]) => {
        console.log('dataaaa', data);

        const filteredRequirement = data.filter((req: Requirement) => req.employeeId === selectedEmployeeId);
        console.log('Filtered Requirement', filteredRequirement);

        if (filteredRequirement.length === 0) {
          this.coreService.openSnackBar("Employee doesn't have Requirements")
        } else {
          const flattenedArray = filteredRequirement[0];
          this.openEditRequirement(flattenedArray);
        }
      }
    );

  }

  onPaymastSelected(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.paymastService.getPaymastByEmployeeId(selectedEmployeeId).subscribe(
      (data: Paymast[]) => {
        console.log('dataaaa', data);
        const filteredPaymast = data.filter((pay: Paymast) => pay.employeeId === selectedEmployeeId);
        console.log('Filtered Employment Background', filteredPaymast);
        if (filteredPaymast.length === 0) {
          this.openPaymastAdd(selectedEmployeeId);
        } else {
          this.coreService.openSnackBar('Employee already have Paymass')
        }
      }
    );

  }

  onPaymastEditSelected(data: any) {

    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.paymastService.getPaymastByEmployeeId(selectedEmployeeId).subscribe(
      (data: Paymast[]) => {
        console.log('dataaaa', data);

        const filteredPaymast = data.filter((pay: Paymast) => pay.employeeId === selectedEmployeeId);
        console.log('Filtered Requirement', filteredPaymast);

        if (filteredPaymast.length === 0) {
          this.coreService.openSnackBar("Employee doesn't have Requirements")
        } else {
          const flattenedArray = filteredPaymast[0];
          this.openPaymastEdit(flattenedArray);
        }
      }
    );

  }

  onBenefitAdd(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.benefitService.getBenefitByEmployeeId(selectedEmployeeId).subscribe(
      (data: Benefit[]) => {
        console.log('dataaaa', data);
        const filteredBenefit = data.filter((ben: Benefit) => ben.employeeId === selectedEmployeeId);
        console.log('Filtered Benefit', filteredBenefit);

        this.openBenefit(selectedEmployeeId);

      }
    );
  }

  onBenefitViewandEdit(data: any) {
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.benefitService.getBenefitByEmployeeId(selectedEmployeeId).subscribe(
      (data: Benefit[]) => {
        console.log('dataaaa', data);

        const filteredBenefit = data.filter((ben: Benefit) => ben.employeeId === selectedEmployeeId);
        console.log('Filtered Benefit', filteredBenefit);
        const flattenedArray = filteredBenefit[0];
        this.openViewEditBenefit(flattenedArray);

      }
    );
  }

  openaddApexMerch(data:any){
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.apexMerchService.getApexMerchByEmployeeId(selectedEmployeeId).subscribe(
      (data: ApexMerch[]) => {
        console.log('dataaaa', data);
        const filterApexMerch = data.filter((apx: ApexMerch) => apx.employeeId === selectedEmployeeId);
        console.log('Filtered Apex Merch', filterApexMerch);

        this.openaddApexMerchDialog(selectedEmployeeId);

      }
    );
  }

  openEditApexMerch(data:any){
    console.log('selected', data);
    const selectedEmployeeId = data.id;
    console.log('selectedID', selectedEmployeeId);

    this.apexMerchService.getApexMerchByEmployeeId(selectedEmployeeId).subscribe(
      (data: ApexMerch[]) => {
        console.log('dataaaa', data);

        const filterApexMerch = data.filter((apx: ApexMerch) => apx.employeeId === selectedEmployeeId);
        console.log('Filtered ApexMerch', filterApexMerch);

        if (filterApexMerch.length === 0) {
          this.coreService.openSnackBar("Employee doesn't have Requirements")
        } else {
          const flattenedArray = filterApexMerch[0];
          this.openEditApexMerchDialog(flattenedArray);
        }
      }
    );
  }

  openAddEducBgform(selectedEmployeeId: string): void {
    const dialogRef = this.dialog.open(EducationComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }


  openeducbgform(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(EditEducationalBgComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  openAddEmpBgForm(selectedEmployeeId: string): void {
    const dialogRef = this.dialog.open(EmploymentBackgroundComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openEditEmpBg(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(EditEmployentBgComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  onEmployeeProfile(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(EmployeeDetailsComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  openAddRequirement(selectedEmployeeId: string): void {
    const dialogRef = this.dialog.open(RequirementsComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  openEditRequirement(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(EditRequirementComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  openPaymastAdd(selectedEmployeeId: string): void {
    const dialogRef = this.dialog.open(PaymastComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
  openPaymastEdit(data: any) {
    console.log('data', data);
    const dialogRef = this.dialog.open(EditPaymastComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

  openBenefit(selectedEmployeeId: any): void {

    const dialogRef = this.dialog.open(BenefitComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }


  openViewEditBenefit(selectedEmployeeId: any) {
    console.log('data', selectedEmployeeId);
    const dialogRef = this.dialog.open(ViewBenefitComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId }, // Pass the data to the dialog
    });
  }

  openaddApexMerchDialog(selectedEmployeeId: any) {
    console.log();
    const dialogRef = this.dialog.open(AddApexMerchComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: { selectedEmployeeId: selectedEmployeeId },
    });
  }

  openEditApexMerchDialog(data : any){
    console.log('data', data);
    const dialogRef = this.dialog.open(EditApexMerchComponent, {
      width: '1000px',
      height: 'auto',
      maxHeight: '90vw',
      data: data,  // Pass the data to the dialog
    });
  }

}
