import { CargoStatu } from "./CargoStatu";
import { Customer } from "./Customer";
import { Product } from "./Product";

export class CargoInfo {
  id!: number;
  cargoNumber!: string;
  customer!: Customer;
  isActive!: boolean;
  deliveryDates!: string;
  currentStatu!: string;
  products!: Product[];
  cargoStatuses!:CargoStatu[];
}
