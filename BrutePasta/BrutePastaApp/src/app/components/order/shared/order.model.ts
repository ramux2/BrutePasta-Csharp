import { Client } from "../../shared/client.model";
import { Item } from "../../shared/item.model";

export interface Order {
    items: Item[],
    client: Client,
    payment: Payment
    deliveryMan: DeliveryMan
}

interface Payment {
    paymentMethod: PaymentMethod
}

interface PaymentMethod {
    id: number,
    name: string,
}

interface DeliveryMan {
    id: number
    cpf: string
    name: string,
    orderTax: number
}