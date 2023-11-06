import { Component, Input, OnInit } from '@angular/core';
import { Item } from '../shared/item.model';
import { CartService } from './shared/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems?: Item[]

  constructor( private cartService: CartService ) {
  }

  ngOnInit() {
    this.cartItems = this.cartService.getCart();
  }



  removeItem(item: Item) {
    this.cartService.removeFromCart(item);
    this.cartItems = this.cartService.getCart();
  }
}
