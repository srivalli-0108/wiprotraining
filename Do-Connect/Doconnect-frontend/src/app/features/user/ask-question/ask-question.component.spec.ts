// src/app/features/user/ask-question/ask-question.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ask-question',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h2>Ask Question</h2>
    <form (ngSubmit)="submit()">
      <textarea [(ngModel)]="question" name="question" placeholder="Your question" required></textarea>
      <button type="submit">Submit</button>
    </form>
    <p>Your question: {{ question }}</p>
  `
})
export class AskQuestionComponent {
  question: string = '';

  constructor() { }

  submit() {
    console.log('Question submitted:', this.question);
    // You can add your service call here if needed
  }
}
