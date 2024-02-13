import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { UserService } from '../../Services/user-services/user.service';
import { CoreService } from '../../Services/core-service/core.service';
import { MaterialModule } from '../../material/material.module';

@Component({
  selector: 'app-add-edit-user',
  standalone: true,
  imports: [MaterialModule],
  templateUrl: './add-edit-user.component.html',
  styleUrl: './add-edit-user.component.css'
})
export class AddEditUserComponent {

  userDetails! :FormGroup
  constructor(
    @Inject(MAT_DIALOG_DATA) public data:any,
    private usersFb: FormBuilder,
    private userService : UserService,
    public dialogRef: MatDialogRef<AddEditUserComponent>,
    private coreService :CoreService
  ){

    this.userDetails = this.usersFb.group({
      id:[''],
      userName : [''],
      employeeNumber : 0,
      password: [''],
      userType: ['']

    })

  }

  ngOnInit(): void {

    console.log("Data Patching", this.data)
    
    this.userDetails.patchValue(this.data)
  }


  onFormSubmit(){
    if(this.userDetails.valid){
      if(this.data){
        this.userService.updateUser(this.data.id, this.userDetails.value)
        .subscribe({
          next:(val:any)=>{
            this.coreService.openSnackBar('Update Successfully')
            console.log('Updated User', val)
            this.dialogRef.close(true);
          },
          error:(err:any)=>{
            this.coreService.openSnackBar('Update Error');
            console.log('Error in Update', err);
          }
        })
      }
      else{
        this.userService.addNewUser(this.userDetails.value).subscribe({
          next:(val:any)=>{
            this.coreService.openSnackBar('User Added Successfully')
            console.log("New User", val)
            this.dialogRef.close(true);
          },
          error:(err:any)=>{
            this.coreService.openSnackBar('User adding error')
            console.log('Error Adding User', err)
          }
        })
      }
    }
  }
}
