export interface Product {
    id: number,
    name: string,
    qtyAvailable: number,
    price: number,
    description: string,
    productType: ProductType
  }
  
  interface ProductType {
    id: number,
    name: string
  }