import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { AuthService } from '../../services/AuthService';

const ProtectedRoute: React.FC = () => {
  return AuthService.isAuthenticated() ? <Outlet /> : <Navigate to="/" />;
};

export default ProtectedRoute;
