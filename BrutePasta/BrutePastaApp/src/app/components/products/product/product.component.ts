import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../shared/product.model';
import { CartService } from '../../cart/shared/cart.service';
import { Item } from '../../shared/item.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() product!: Product;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {

  }

  addToCart(product: Product) {
    const item: Item = {
      id: 0,
      quantity: 1,
      product: product
    };

    this.cartService.addToCart(item);
    console.log("Produto adicionado" + item.product.name)
  }
}
