import React, { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { BookingService } from '../services/BookingService';

const CreateBooking: React.FC = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [startTime, setStartTime] = useState('');
    const [endTime, setEndTime] = useState('');
    const [error, setError] = useState<string | null>(null);

    const { customerId } = useParams<{ customerId: string }>();
    const navigate = useNavigate();

    const handleCreateBooking = async () => {
        setError(null);

        if (!name || !description || !startTime || !endTime || !customerId) {
            setError('Please fill in all required fields');
            return;
        }

        try {
            const newBooking = {
                name,
                description,
                startTime: new Date(startTime),
                endTime: new Date(endTime),
                customerId: customerId, // Ensure customerId is being sent correctly
            };
            console.log('Creating booking with data:', newBooking);
            await BookingService.create(newBooking);
            console.log('Booking created successfully');
            navigate(`/customers/${customerId}`); // Redirect after successful creation
        } catch (error: any) {
            console.error('Failed to create booking:', error);
            setError('Failed to create booking.');
        }
    };

    return (
        <div className="page">
            <main className="content">
                <div className="card">
                    <h3>Create New Booking</h3>
                    {error && <p style={{ color: 'red' }}>{error}</p>}

                    <input
                        type="text"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        placeholder="Name"
                    />
                    <input
                        type="text"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        placeholder="Description"
                    />
                    <input
                        type="datetime-local"
                        value={startTime}
                        onChange={(e) => setStartTime(e.target.value)}
                        placeholder="Start Time"
                    />
                    <input
                        type="datetime-local"
                        value={endTime}
                        onChange={(e) => setEndTime(e.target.value)}
                        placeholder="End Time"
                    />

                    <button onClick={handleCreateBooking}>Add Booking</button>
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

export default CreateBooking;
