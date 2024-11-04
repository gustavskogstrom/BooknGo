import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './components/Auth/Login';
import CustomerList from './components/CustomerList';
import CreateCustomer from './components/CreateCustomer';
import Header from './components/ui/Header/Header';
import './styles/App.css';
import './styles/Login.css';
import CustomerDetails from './components/CustomerDetails';
import CreateBooking from './components/CreateBooking';
import ProtectedRoute from './components/Auth/ProtectedRoute';

const App: React.FC = () => {
  return (
    <Router>
      <div className="app">
        <Header />
        <main className="main-content">
          <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/login" element={<Login />} />
            
            <Route element={<ProtectedRoute />}>
            <Route path="/customers" element={<CustomerList />} />
            <Route path="/create-customer" element={<CreateCustomer />} />
            <Route path="/customers/:customerId" element={<CustomerDetails />} />
            <Route path="/create-booking/:customerId" element={<CreateBooking />} />
            </Route>
          </Routes>
        </main>
      </div>
    </Router>
  );
};

export default App;
