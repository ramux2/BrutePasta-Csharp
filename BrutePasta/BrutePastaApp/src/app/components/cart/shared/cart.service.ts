import { Injectable, Input } from '@angular/core';
import { Item } from '../../shared/item.model';
import { Order } from '../../order/shared/order.model';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OrderService } from '../../order/shared/order.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  @Input() order!: Order;
  cartItems: Item[] = [];
  cpfForm!: FormGroup;
  formBuilder!: FormBuilder;
  

  constructor( private orderService: OrderService) {
    // Carregue os itens do carrinho do localStorage no construtor
    const storedCart = localStorage.getItem('cartItems');

    if (storedCart) {
      this.cartItems = JSON.parse(storedCart);
    }
  }

  ngOnInit() {
    this.cpfForm = this.formBuilder.group({
      cpf: [null],
    })
  }

  getCart(): Item[] {
    return this.cartItems;
  }

  calculateSubTotal(item: Item): number {
    return item.quantity * item.product.price;
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

    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
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

    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }

  removeAllFromCart(item: Item) {
    const index = this.cartItems.indexOf(item);
    if (index !== -1) {
      this.cartItems.splice(index, 1);
    }

    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }

  clearCart() {
    this.cartItems = [];

    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }

  finalizeOrder() {
    const order: Order = {
      items: this.getCart(),
      payment: {
        paymentMethod: {
          id: 1, // Defina o método de pagamento desejado
          name: ''
        },
      },
      client: {
        id: 2, // Defina o cliente ou outras informações necessárias
        cpf: '',
        name: '',
        email: '',
        password: '',
        phoneNumber: ''
      },
      deliveryMan: {
        id: 0,
        cpf: '',
        name: '',
        orderTax: 0
      }
    }
    console.log(order);
    this.orderService.createOrder(order).subscribe((response) => {
      console.log("Deu boa caralho")
      this.clearCart();
      // this.router.navigate(['/confirmation-page']);
    });
    this.clearCart();
    localStorage.removeItem('cartItems');
  }
}
