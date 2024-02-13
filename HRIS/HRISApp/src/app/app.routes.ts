import { Routes } from '@angular/router';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { EmployeeListComponent } from './201File-Folder/employee-list/employee-list.component';

import { LoginPageComponent } from './login-page/login-page.component';

import { LeavesComponent } from './Leaves-folder/leaves/leaves.component';
import { LeaveListComponent } from './Leaves-folder/leave-list/leave-list.component';
import { AuthGuardGuard } from './Services/user-services/guard/auth-guard.guard';
import { ManageLeaveComponent } from './Leaves-folder/manage-leave/manage-leave.component';
import { UserListComponent } from './user-folder/user-list/user-list.component';
import { AddEditUserComponent } from './user-folder/add-edit-user/add-edit-user.component';
import { ChangepassComponent } from './changepass/changepass.component';
import { ManagerGuard } from './Services/user-services/manager.guard';


export const routes: Routes = [
    {
    path: 'Dashboard',
    component: AppLayoutComponent,
    canActivate: [AuthGuardGuard],
    children: [
        { 
        path: 'employee-list', 
        component: EmployeeListComponent 
        },    
       
        {
            path:'leave',
            component:LeavesComponent
        },
        {
            path:'leavelist',
            component: LeaveListComponent
        },
        {
            path: 'manageleave',
            component: ManageLeaveComponent,
            canActivate: [ManagerGuard]
        },
        {
            path:'userlist',
            component:UserListComponent
        },
        
        
    ],
    },
    {
        path:'',
        redirectTo:'login',
        pathMatch:'full'
    },
    {
        path: 'login',
        component: LoginPageComponent,
    },
    {
        path:'changepass',
        component:ChangepassComponent
    }
    
];

