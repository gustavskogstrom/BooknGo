import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { CustomerService } from '../services/CustomerService';
import { Customer } from '../interfaces/Customer';

const CustomerList: React.FC = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetchCustomers();
  }, []);

  const fetchCustomers = async () => {
    try {
      const data = await CustomerService.getAll();
      setCustomers(data);
    } catch (error) {
      setError('Failed to fetch customers.');
    }
  };

  const handleDelete = async (id: string) => {
    const isConfirmed = window.confirm('Are you sure you want to delete this customer?');
    if (!isConfirmed) {
      return;
    }

    try {
      await CustomerService.delete(id);
      setCustomers(customers.filter((customer) => customer.id !== id));
    } catch (error) {
      setError('Failed to delete the customer.');
    }
  };

  return (
    <div className="page">
      <main className="content">
        <div className="card">
          <h3>Customer List</h3>
          {error && <p style={{ color: 'red' }}>{error}</p>}
          <ul>
            {customers.map((customer) => (
              <li key={customer.id}>
                <p>{customer.name} - {customer.email}</p>
                <button onClick={() => navigate(`/customers/${customer.id}`)}>More Details</button>
                <button onClick={() => handleDelete(customer.id)}>Delete</button>
              </li>
            ))}
          </ul>
          <button onClick={() => navigate('/create-customer')} style={{ marginTop: '20px' }}>
            Add New Customer
          </button>
        </div>
      </main>
    </div>
  );
};

export default CustomerList;
