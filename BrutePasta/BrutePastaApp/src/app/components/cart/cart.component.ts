import { Component, Input, OnInit } from '@angular/core';
import { Item } from '../shared/item.model';
import { CartService } from './shared/cart.service';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  cartItems?: Item[]

  constructor( private cartService: CartService) {
  }

  calculateSubtotal(item: Item): number {
    return item.quantity * item.product.price;
  }

  calculateTotal(): number {
    const cartItems = this.cartService.getCart();
    let total = 0;

    for (const item of cartItems) {
      total += this.cartService.calculateSubTotal(item);
    }

    return total + 20;
  }

  ngOnInit() {
    this.cartItems = this.cartService.getCart();
  }

  removeItem(item: Item) {
    this.cartService.removeFromCart(item);
    this.cartItems = this.cartService.getCart();
  }

  removeAll(item: Item) {
    this.cartService.removeAllFromCart(item);
    this.cartItems = this.cartService.getCart();
  }
  
  clearCart() {
    this.cartService.clearCart();
    this.cartItems = this.cartService.getCart();
  }
  
  finalizeOrder() {
    this.cartService.finalizeOrder();
    this.cartItems = this.cartService.getCart();
  }
}
