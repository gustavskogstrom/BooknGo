import axios from 'axios';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;

export const AuthService = {
  login: async (email: string, password: string) => {
    try {
      const response = await axios.post(
        `${API_BASE_URL}/login`,
        { email, password }, // Skickar "email" istället för "userName"
        { withCredentials: true }
      );

      if (response.status === 200) {
        const token = response.data.token;
        localStorage.setItem('authToken', token);
        return token;
      } else {
        throw new Error('Unexpected response status.');
      }
    } catch (error: any) {
      console.error('Login error:', error.response?.data || error.message);
      throw new Error(error.response?.data?.message || 'Login failed. Please try again.');
    }
  },

  logout: () => {
    localStorage.removeItem('authToken');
  },

  isAuthenticated: () => {
    return localStorage.getItem('authToken') !== null;
  },
};
