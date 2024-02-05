import { Routes } from '@angular/router';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import { EmployeeListComponent } from './201File-Folder/employee-list/employee-list.component';
import { BookComponent } from './book/book.component';
import { LoginPageComponent } from './login-page/login-page.component';

import { LeavesComponent } from './Leaves-folder/leaves/leaves.component';
import { LeaveListComponent } from './Leaves-folder/leave-list/leave-list.component';
import { AuthGuardGuard } from './Services/user-services/guard/auth-guard.guard';

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
        path: 'book', 
        component: BookComponent 
        }, 
        {
            path:'leave',
            component:LeavesComponent
        },
        {
            path:'leavelist',
            component: LeaveListComponent
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
    }
];

