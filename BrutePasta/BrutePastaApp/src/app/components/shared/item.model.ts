import { Product } from "../products/shared/product.model"

export interface Item {
    id: number,
    quantity: number,
    product: Product 
}
  