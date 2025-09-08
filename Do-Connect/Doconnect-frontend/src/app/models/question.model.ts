

export interface Question {
  id: number;
  title: string;
  description: string;
  status: 'pending' | 'approved' | 'rejected';
  userId: number;
  createdAt: Date;
  updatedAt?: Date;
}
