// src/app/features/models/user.model.ts

export interface User {
  id: number;
  username: string;
  email: string;
  role: 'user' | 'admin';
  createdAt: Date;
  updatedAt?: Date;
}
