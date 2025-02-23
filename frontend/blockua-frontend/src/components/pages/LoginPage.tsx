import React, { useState } from "react";
import "../css/LoginPage.css"; 

const LoginPage: React.FC = () => {
  const [email, setEmail] = useState<string>('');

  const handleLogin = () => {
    alert(`Logging in with email: ${email}`);
  };

  const handleGoogleLogin = () => {
    alert('Logging in with Google');
  };

  const handleAppleLogin = () => {
    alert('Logging in with Apple');
  };

  const handleTelegramLogin = () => {
    alert('Logging in with Telegram');
  };

  return (
    <div className="login-container">
      <div className="logo-container">
        <img
          src="https://storage.googleapis.com/a1aa/image/m3VVKp9YzWTMZwVKjudUHCUbkJNKvTWiTXp7uqw_JO8.jpg"
          alt="BINANCE Logo"
          width="150"
          height="50"
        />
      </div>
      <h2>Увійти</h2>
      <form id="loginForm" className="login-form">
        <label htmlFor="email">Ел. пошта/номер телефону</label>
        <input
          type="text"
          id="email"
          placeholder="Ел. адреса/телефон (без коду країни)"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="login-input"
        />
        <button type="button" className="login-button" onClick={handleLogin}>
          Далі
        </button>
        <div className="separator">
          <span>або</span>
        </div>
        <button type="button" className="social-button google" onClick={handleGoogleLogin}>
          <i className="fab fa-google"></i> Продовжити з Google
        </button>
        <button type="button" className="social-button apple" onClick={handleAppleLogin}>
          <i className="fab fa-apple"></i> Продовжити з Apple
        </button>
        <button type="button" className="social-button telegram" onClick={handleTelegramLogin}>
          <i className="fab fa-telegram"></i> Продовжити з Telegram
        </button>
      </form>
      <div className="signup-link">
        <a href="#">Створити акаунт Binance</a>
      </div>
      <footer className="footer">
        <a href="#">Українська</a>
        <a href="#">Файли cookie</a>
        <a href="#">Умови</a>
        <a href="#">Конфіденційність</a>
      </footer>
    </div>
  );
};

export default LoginPage;
