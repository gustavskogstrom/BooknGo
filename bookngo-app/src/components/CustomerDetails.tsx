import React, { useEffect, useState } from 'react';
import { useParams, useNavigate, Link } from 'react-router-dom';
import { CustomerService } from '../services/CustomerService';
import { Customer } from '../interfaces/Customer';
import { Booking } from '../interfaces/Booking';
import { BookingService } from '../services/BookingService';

const CustomerDetails: React.FC = () => {
  const { customerId } = useParams<{ customerId: string }>();
  const [customer, setCustomer] = useState<Customer | null>(null);
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const navigate = useNavigate();

  useEffect(() => {
    if (customerId) {
      console.log('Fetching customer details for ID:', customerId);
      fetchCustomerDetails(customerId);
    } else {
      console.error('No customer ID provided in URL params');
      setError('Customer ID is missing. Redirecting to customer list.');
      setTimeout(() => navigate('/customers'), 3000);
    }
  }, [customerId, navigate]);

  const fetchCustomerDetails = async (id: string) => {
    try {
      setError(null);
      setLoading(true);
      console.log('Attempting to fetch customer details from API');
      const customerData = await CustomerService.getById(id);
      console.log('Customer data fetched successfully:', customerData);
      if (!customerData) {
        throw new Error('No customer data returned from API');
      }
      setCustomer(customerData);
      
      if (customerData.bookings && Array.isArray(customerData.bookings)) {
        console.log('Customer bookings fetched successfully:', customerData.bookings);
        setBookings(customerData.bookings);
      } else {
        console.warn('No bookings found or bookings data is not an array');
        setBookings([]);
      }
    } catch (err: any) {
      setError('Failed to fetch customer details. Please try again.');
      console.error('Error fetching customer details:', err);
    } finally {
      setLoading(false);
    }
  };
  const handleDelete = async (id: string) => {
    const isConfirmed = window.confirm('Are you sure you want to delete this booking?');
    if (!isConfirmed) {
      return;
    }

    try {
      await BookingService.delete(id);
      setBookings(bookings.filter((booking) => booking.id !== id));
    } catch (error) {
      setError('Failed to delete the customer.');
    }
  };

  const handleCreateBooking = async () => {
    if (customer) {
      console.log('Navigating to create booking for customer ID:', customer.id);
      await navigate(`/create-booking/${customer.id}`);
      fetchCustomerDetails(customer.id);
    }
  };

  return (
    <div className="page">
      <main className="content">
        <div className="card">
          <h2>{customer?.name || 'Customer Details'}</h2>
          {error && <p className="error" style={{ color: 'red' }}>{error}</p>}
          {loading ? (
            <p>Loading customer details...</p>
          ) : customer ? (
            <div>
              <p><strong>Email:</strong> {customer.email}</p>

              <h3>Bookings</h3>
              <ul>
                {bookings.length > 0 ? (
                  bookings.map((booking) => (
                    <li key={booking.id}>
                      <p><strong>Booking Name:</strong> {booking.name}</p>
                      <p><strong>Description:</strong> {booking.description}</p>
                      <p><strong>Start Time:</strong> {new Date(booking.startTime).toLocaleString()}</p>
                      <p><strong>End Time:</strong> {new Date(booking.endTime).toLocaleString()}</p>
                      <button onClick={() => handleDelete(booking.id)}>Delete</button>
                    </li>
                  ))
                ) : (
                  <p>No bookings available</p>
                )}
              </ul>
              <button onClick={handleCreateBooking} style={{ marginTop: '20px' }}>Create New Booking</button>
              <button onClick={() => navigate('/customers')} style={{ marginTop: '20px' }}>
                Back to Customer List
              </button>
            </div>
          ) : null}
        </div>
      </main>
    </div>
  );
};

export default CustomerDetails;