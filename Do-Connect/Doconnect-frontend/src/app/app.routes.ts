import { Routes } from '@angular/router';
import { LoginComponent } from './core/auth/login/login.component';
import { RegisterComponent } from './core/auth/register/register.component';
import { AskQuestionComponent } from './features/user/ask-question/ask-question.component';
import { DashboardComponent } from './features/user/dashboard/dashboard.component';
import { ViewQuestionComponent } from './features/user/view-question/view-question.component';
import { AdminDashboardComponent } from './features/admin/admin-dashboard/admin-dashboard.component';
import { AdminApprovalComponent } from './features/admin/admin-approval/admin-approval.component';
import { HomeComponent } from './features/home/home.component';
import { AboutComponent } from './features/about/about.component';
import { AuthGuard } from './core/guards/auth.guard';
import { AdminGuard } from './core/guards/admin.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'ask-question', component: AskQuestionComponent, canActivate: [AuthGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'view-question/:id', component: ViewQuestionComponent, canActivate: [AuthGuard] },
  { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AdminGuard] },
  { path: 'admin-approval', component: AdminApprovalComponent, canActivate: [AdminGuard] },
  { path: '**', redirectTo: '' }
];
