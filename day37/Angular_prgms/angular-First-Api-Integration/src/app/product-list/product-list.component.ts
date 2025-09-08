import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: any[] = [];

  constructor(private ProductService: ProductService) { }

  ngOnInit(): void {
    this.ProductService.getProducts().subscribe(data => {
      console.log('API response:', data);
      this.products = data;
    });
  }

}
