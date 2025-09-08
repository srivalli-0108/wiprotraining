// src/app/core/auth/register/register.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username = '';
  email = '';
  password = '';
  error = '';
  success = '';

  constructor(private registerService: RegisterService) {}

  onSubmit() {
    this.error = '';
    this.success = '';
    this.registerService.register({
      username: this.username,
      email: this.email,
      password: this.password,
    }).subscribe({
      next: () => this.success = 'Registration successful!',
      error: (err) => this.error = err.message || 'Registration failed.',
    });
  }
}
