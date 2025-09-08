import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  @Input() product!: { id: number; name: string; price: number };
  @Output() feedbackEvent = new EventEmitter<{ productId: number; feedback: string }>();

  userFeedback: string = '';

  sendFeedback() {
    if (this.userFeedback.trim()) {
      this.feedbackEvent.emit({
        productId: this.product.id,
        feedback: this.userFeedback
      });
      this.userFeedback = ''; // Clear input after sending
    }
  }
}
