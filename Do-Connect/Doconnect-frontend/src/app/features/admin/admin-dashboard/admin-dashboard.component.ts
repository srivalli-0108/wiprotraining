import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { AdminService } from "../../../core/services/admin.services";

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']  // ✅ make sure this file exists!
})
export class AdminDashboardComponent {
  notifications: any[] = [];       // ✅ declared
  pendingQuestions: any[] = [];    // ✅ declared
  pendingAnswers: any[] = [];      // ✅ declared

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.loadNotifications();
    this.loadPendingQuestions();
    this.loadPendingAnswers();
  }

  loadNotifications() {
    this.adminService.getNotifications().subscribe({
      next: (data) => this.notifications = data,
      error: (err) => console.error('Error fetching notifications', err)
    });
  }

  loadPendingQuestions() {
    this.adminService.getPendingQuestions().subscribe({
      next: (data) => this.pendingQuestions = data,
      error: (err) => console.error('Error fetching pending questions', err)
    });
  }

  loadPendingAnswers() {
    this.adminService.getPendingAnswers().subscribe({
      next: (data) => this.pendingAnswers = data,
      error: (err) => console.error('Error fetching pending answers', err)
    });
  }

  approveQuestion(id: number) {
    this.adminService.approveQuestion(id).subscribe({
      next: () => this.loadPendingQuestions(),
      error: (err) => console.error('Error approving question', err)
    });
  }

  rejectQuestion(id: number) {
    this.adminService.rejectQuestion(id).subscribe({
      next: () => this.loadPendingQuestions(),
      error: (err) => console.error('Error rejecting question', err)
    });
  }

  approveAnswer(id: number) {
    this.adminService.approveAnswer(id).subscribe({
      next: () => this.loadPendingAnswers(),
      error: (err) => console.error('Error approving answer', err)
    });
  }

  rejectAnswer(id: number) {
    this.adminService.rejectAnswer(id).subscribe({
      next: () => this.loadPendingAnswers(),
      error: (err) => console.error('Error rejecting answer', err)
    });
  }
}
