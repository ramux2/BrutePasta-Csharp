import { Injectable } from '@angular/core';
import { Item } from '../../shared/item.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  cartItems: Item[] = [];

  getCart(): Item[] {
    return this.cartItems;
  }

  addToCart(item: Item) {
    const existingItem = this.cartItems.find((i) => i.product.id === item.product.id);

    if (existingItem) {
      // Se o produto já existe no carrinho, atualize a quantidade
      existingItem.quantity += item.quantity;
    } else {
      // Caso contrário, adicione o novo item
      this.cartItems.push(item);
    }
  }

  removeFromCart(item: Item) {
    const index = this.cartItems.indexOf(item);
    if (index !== -1) {
      if (item.quantity > 1) {
        item.quantity -= 1;
      } else{
        this.cartItems.splice(index, 1);
      }
    }
  }

  clearCart() {
    this.cartItems = [];
  }
}
