import React from 'react';

export const Header: React.FC = () => {
  return (
    <header>
      <div className="left">
        <img
          src="https://storage.googleapis.com/a1aa/image/ZWUgvZs7T0y8-jIxTlGf0yEdjva99wyVgiXr0r6_eHA.jpg"
          alt="Binance logo"
        />
        <nav>
          <a href="#">Купівля криптовалют</a>
          <a href="#">Ринки</a>
          <a href="#">Торгіля</a>
        </nav>
      </div>
      <div className="right">
        <i className="fas fa-user-circle"></i>
      </div>
    </header>
  );
};
