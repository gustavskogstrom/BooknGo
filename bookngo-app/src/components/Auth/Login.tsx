import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { AuthService } from '../../services/AuthService';
import "../../styles/Login.css"

const Login: React.FC = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      await AuthService.login(userName, password);
      navigate('/customers');
    } catch (error) {
      setError('Login failed. Please try again.');
    }
  };

  return (
    <div className="page">
      <main className="content">
        <div className="card">
          <h2>Login</h2>
          {error && <div className="error">{error}</div>}
          <label>Email</label>
          <input
            type="text"
            placeholder="Email"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
          <label>Password</label>
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <button onClick={handleLogin}>Login</button>
        </div>
      </main>
    </div>
  );
};

export default Login;
