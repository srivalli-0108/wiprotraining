import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

interface Question {
  id: number;
  title: string;
  description: string;
  status: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  questions: Question[] = [];

  ngOnInit() {
    // TODO: Replace with API call to fetch user's questions
    this.questions = [
      { id: 1, title: 'How to use Angular?', description: 'I want to learn Angular basics.', status: 'approved' },
      { id: 2, title: 'What is Entity Framework?', description: 'Explanation needed.', status: 'pending' }
    ];
  }
}
