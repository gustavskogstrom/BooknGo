import axios from 'axios';
import { Booking } from '../interfaces/Booking';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const BookingService = {
  getAll: async (): Promise<Booking[]> => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/Bookings`, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to fetch bookings:', error.response?.data || error.message);
      throw new Error('Failed to fetch bookings.');
    }
  },

  getById: async (id: string): Promise<Booking> => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/Bookings/${id}`, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to fetch booking details:', error.response?.data || error.message);
      throw new Error('Failed to fetch booking details.');
    }
  },

  create: async (bookingData: Partial<Booking>): Promise<Booking> => {
    try {
        const response = await axios.post(`${API_BASE_URL}/api/Bookings`, bookingData, {
            withCredentials: true, // Ensures cookies are sent for authentication
        });
        return response.data;
    } catch (error: any) {
        console.error('Failed to create booking:', error.response?.data || error.message);
        throw new Error('Failed to create booking.');
    }
},

  update: async (id: string, bookingData: Partial<Booking>): Promise<Booking> => {
    try {
      const response = await axios.put(`${API_BASE_URL}/api/Bookings/${id}`, bookingData, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to update booking:', error.response?.data || error.message);
      throw new Error('Failed to update booking.');
    }
  },

  delete: async (id: string): Promise<void> => {
    try {
      await axios.delete(`${API_BASE_URL}/api/Bookings/${id}`, {
        withCredentials: true,
      });
    } catch (error: any) {
      console.error('Failed to delete booking:', error.response?.data || error.message);
      throw new Error('Failed to delete booking.');
    }
  },

  getByCustomerId: async (customerId: string): Promise<Booking[]> => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/bookings/customer/${customerId}`, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to fetch bookings by customer ID:', error.response?.data || error.message);
      throw new Error('Failed to fetch bookings by customer ID.');
    }
  },

  createBooking: async (customerId: string, booking: Booking) => {
    return await axios.post(`${API_BASE_URL}/api/bookings/customer/${customerId}/createBooking`, booking, {
      withCredentials: true,
      headers: {
        'Content-Type': 'application/json',
      },
    });
  },
};
