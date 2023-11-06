import { Product } from "../../products/shared/product.model";

export interface Cart {
    id: number;
    product: Product;
    quantity: number;
  }