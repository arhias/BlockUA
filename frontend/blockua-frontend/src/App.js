import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import DashboardPage from "./components/pages/DashboardPage.tsx";
import LoginPage from "./components/pages/LoginPage.tsx";
import CryptoPurchasePage from "./components/pages/CryptoPurchasePage.tsx";
import TradingPage from "./components/pages/TradingPage.tsx";
import HomePage from "./components/pages/HomePage.tsx";
import RegistrationPage from "./components/pages/RegistrationPage.tsx";

import './App.css'; 

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/registration" element={<RegistrationPage />} />
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/dashboard" element={<DashboardPage />} />
        <Route path="/crypto-purchase" element={<CryptoPurchasePage />} />
        <Route path="/trading" element={<TradingPage />} />
      </Routes>
    </Router>
  );
}

export default App;
