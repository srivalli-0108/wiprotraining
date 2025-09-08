import { Component, OnInit } from '@angular/core';
import { AdminService } from "../../../core/services/admin.services";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-approve',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './admin-approval.component.html',
  styleUrls: ['./admin-approval.component.css']
})
export class AdminApprovalComponent implements OnInit {

  pendingQuestions: any[] = [];
  pendingAnswers: any[] = [];

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.loadPendingContent();
  }

  loadPendingContent() {
    this.adminService.getPendingQuestions().subscribe(
      (questions) => this.pendingQuestions = questions,
      (error) => console.error('Error loading questions:', error)
    );

    this.adminService.getPendingAnswers().subscribe(
      (answers) => this.pendingAnswers = answers,
      (error) => console.error('Error loading answers:', error)
    );
  }

  approveQuestion(id: number) {
    this.adminService.approveQuestion(id).subscribe(() => this.loadPendingContent());
  }

  rejectQuestion(id: number) {
    this.adminService.rejectQuestion(id).subscribe(() => this.loadPendingContent());
  }

  approveAnswer(id: number) {
    this.adminService.approveAnswer(id).subscribe(() => this.loadPendingContent());
  }

  rejectAnswer(id: number) {
    this.adminService.rejectAnswer(id).subscribe(() => this.loadPendingContent());
  }
}
