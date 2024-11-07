import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { CustomerService } from '../services/CustomerService';

const EditCustomer: React.FC = () =>  {
    const { Id } = useParams<{ Id: string }>();
    const [name, setName] = useState('');
    const  [email, setEmail] = useState('');
    const [error, setError] = useState<string | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchCustomer = async () => {
            try {
                const customer = await CustomerService.getById(Id!);
                setName(customer.name);
                setEmail(customer.email);
            } catch (error) {
                setError('Failed to load data');
            }
        };
        
        if (Id) { 
            fetchCustomer();
        }
    }, [Id]);


    // const handleEditCustomer = async () => {
    //     setError(null);

    //     if 
    // }

    return(
        <div className="page">
      <main className="content">
        {/* <div className="card">
          <h3>Edit Customer</h3>
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
        </div> */}
      </main>
    </div>
    );
}
export default EditCustomer