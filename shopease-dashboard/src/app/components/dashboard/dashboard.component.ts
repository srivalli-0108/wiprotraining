import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  products = [
    { id: 1, name: 'Smartphone', price: 25000 },
    { id: 2, name: 'Laptop', price: 55000 },
    { id: 3, name: 'Headphones', price: 2000 }
  ];

  selectedProduct: any = null;
  feedbackList: { productId: number; feedback: string }[] = [];

  selectProduct(product: any) {
    this.selectedProduct = product;
  }

  receiveFeedback(event: { productId: number; feedback: string }) {
    this.feedbackList.push(event);
  }
}
