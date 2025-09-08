// src/app/features/user/view-question/view-question.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

interface Answer {
  id: number;
  userName: string;
  text: string;
  date: Date;
}

@Component({
  selector: 'app-view-question',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './view-question.component.html',
  styleUrls: ['./view-question.component.css']
})
export class ViewQuestionComponent implements OnInit {
  questionId!: number;
  question: { title: string; description: string } | undefined;
  answers: Answer[] = [];
  answerForm: FormGroup;

  constructor(private route: ActivatedRoute, private fb: FormBuilder) {
    this.answerForm = this.fb.group({
      answerText: ['', Validators.required],
      image: [null]
    });
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.questionId = +params['id'];
      this.question = { title: 'Sample Title', description: 'Sample description' };
      this.answers = [
        { id: 1, userName: 'Srivalli', text: 'You can start with docs.', date: new Date() },
        { id: 2, userName: 'Asmi', text: 'Try tutorials.', date: new Date() }
      ];
    });
  }

  onFileChange(event: any) {
    if (event.target.files.length) {
      this.answerForm.patchValue({ image: event.target.files[0] });
    }
  }

  submitAnswer() {
    if (this.answerForm.valid) {
      const formData = new FormData();
      formData.append('answerText', this.answerForm.get('answerText')!.value);
      const img = this.answerForm.get('image')!.value;
      if (img) formData.append('image', img);
      console.log('Answer submitted:', formData);
    }
  }
}
