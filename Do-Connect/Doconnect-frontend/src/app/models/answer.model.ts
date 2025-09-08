

export interface Answer {
  id: number;
  questionId: number;
  text: string;
  status: 'pending' | 'approved' | 'rejected';
  userId: number;
  createdAt: Date;
  updatedAt?: Date;
}
