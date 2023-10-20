import { Component, OnInit } from '@angular/core';
import { ProductService } from '../shared/product.service';
import { Product } from '../shared/product.model';

@Component({
  selector: 'app-get-products',
  templateUrl: './get-products.component.html',
  styleUrls: ['./get-products.component.css']
})


export class GetProductsComponent implements OnInit {
  listProducts: Product[] = [];
  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.service.products().subscribe((listProducts) => {
      this.listProducts = listProducts
    })
  }
}
