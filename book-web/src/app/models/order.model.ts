export interface Order {
  id?: number;
  orderNumber?: string;
  title: string;
  price: number;
  store: string;
  totalPaid?: number;
}