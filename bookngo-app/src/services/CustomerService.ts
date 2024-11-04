import axios from 'axios';
import { Customer } from '../interfaces/Customer';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const CustomerService = {
  getAll: async (): Promise<Customer[]> => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/Customers`, {
        withCredentials: true,
      });
      console.log(123)
      return response.data;
    } catch (error: any) {
      console.error('Failed to fetch customers:', error.response?.data || error.message);
      throw new Error('Failed to fetch customers.');
    }
  },

  getById: async (id: string): Promise<Customer> => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/Customers/${id}`, {
        withCredentials: true,
      });
      console.log(id)
      return response.data;
    } catch (error: any) {
      console.error('Failed to fetch customer details:', error.response?.data || error.message);
      throw new Error('Failed to fetch customer details.');
    }
  },

  create: async (customerData: Partial<Customer>): Promise<Customer> => {
    try {
      const response = await axios.post(`${API_BASE_URL}/api/Customers`, customerData, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to create customer:', error.response?.data || error.message);
      throw new Error('Failed to create customer.');
    }
  },

  update: async (id: string, customerData: Partial<Customer>): Promise<Customer> => {
    try {
      const response = await axios.put(`${API_BASE_URL}/api/Customers/${id}`, customerData, {
        withCredentials: true,
      });
      return response.data;
    } catch (error: any) {
      console.error('Failed to update customer:', error.response?.data || error.message);
      throw new Error('Failed to update customer.');
    }
  },

  delete: async (id: string): Promise<void> => {
    try {
      await axios.delete(`${API_BASE_URL}/api/Customers/${id}`, {
        withCredentials: true,
      });
    } catch (error: any) {
      console.error('Failed to delete customer:', error.response?.data || error.message);
      throw new Error('Failed to delete customer.');
    }
  },
};
