import { Booking } from "./Booking";

export interface Customer {
    id: string;
    name: string;
    email: string;
    bookings: Booking[];
}