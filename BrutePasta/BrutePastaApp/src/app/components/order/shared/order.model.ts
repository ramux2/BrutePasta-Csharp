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

interface Client {
    id: number,
    cpf: string,
    name: string,
    email: string,
    password: string,
    phoneNumber: string
}

interface DeliveryMan {
    id: number
    cpf: string
    name: string,
    orderTax: number
}