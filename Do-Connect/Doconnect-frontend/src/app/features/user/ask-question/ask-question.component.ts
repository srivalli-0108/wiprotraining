// src/app/user/ask-question/ask-question.component.ts

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-ask-question',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './ask-question.component.html',
  styleUrls: ['./ask-question.component.css']
})
export class AskQuestionComponent {
  askForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.askForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      image: [null]
    });
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    this.askForm.patchValue({ image: file });
  }

  submitQuestion() {
    if (this.askForm.valid) {
      const formData = new FormData();
      formData.append('title', this.askForm.get('title')?.value);
      formData.append('description', this.askForm.get('description')?.value);

      const imageFile = this.askForm.get('image')?.value;
      if (imageFile) {
        formData.append('image', imageFile);
      }

      // TODO: Call your API service to send this data to backend
      console.log('Question submitted:', formData);
    }
  }
}
