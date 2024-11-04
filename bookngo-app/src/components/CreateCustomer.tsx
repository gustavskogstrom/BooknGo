import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { CustomerService } from '../services/CustomerService';

const CreateCustomer: React.FC = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  const handleCreateCustomer = async () => {
    setError(null);

    if (!name || !email) {
      setError('Please fill in all required fields');
      return;
    }

    try {
      const newCustomer = {
        name,
        email,
      };
      await CustomerService.create(newCustomer);
      navigate('/customers'); // Redirect after successful creation
    } catch (error: any) {
      console.error('Failed to create customer:', error);
      setError('Failed to create customer.');
    }
  };

  return (
    <div className="page">
      <main className="content">
        <div className="card">
          <h3>Create New Customer</h3>
          {error && <p style={{ color: 'red' }}>{error}</p>}

          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
            placeholder="Name"
          />
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Email"
          />

          <button onClick={handleCreateCustomer}>Add Customer</button>
          <div>
            <button onClick={() => navigate('/customers')} style={{ marginTop: '20px' }}>
              Cancel
            </button>
          </div>
        </div>
      </main>
    </div>
  );
};

export default CreateCustomer;