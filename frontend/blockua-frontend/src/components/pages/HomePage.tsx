import React from "react";
import { Link } from "react-router-dom"; // Импортируем Link
const HomePage: React.FC = () => {
  return (
    <div style={{ backgroundColor: "#1a202c", color: "white", fontFamily: "Arial, sans-serif", margin: 0, padding: 0 }}>
      <header style={{ display: "flex", justifyContent: "space-between", alignItems: "center", padding: "16px" }}>
        <div className="logo-container">
          <img src="https://storage.googleapis.com/a1aa/image/mLUlnsEd-NQWnSyhkjnOTDz6QWvXt95FqPj64GhRTZc.jpg" alt="Binance Logo" style={{ height: "40px" }} />
          <nav style={{ display: "none" }}>
            <a href="#">Купівля криптовалют</a>
            <a href="#">Ринки</a>
            <a href="#">Торгівля</a>
            <a href="#">Ф'ючерси</a>
            <a href="#">Earn</a>
            <a href="#">Square</a>
            <a href="#">Більше</a>
          </nav>
        </div>
        <div className="auth-buttons" style={{ display: "flex", alignItems: "center" }}>
        <Link to="/login">
          <button style={{ marginLeft: "16px", backgroundColor: "#fbbf24", color: "black", padding: "8px 16px", border: "none", borderRadius: "4px", cursor: "pointer" }}>Вхід</button>
          </Link>
          
          <Link to="/registration">
             <button style={{ marginLeft: "16px", backgroundColor: "#fbbf24", color: "black", padding: "8px 16px", border: "none", borderRadius: "4px", cursor: "pointer" }}>Зареєструватися</button>
             </Link>
        </div>
      </header>
      <main style={{ display: "flex", flexDirection: "column", alignItems: "center", padding: "32px" }}>
        <div className="left-section" style={{ textAlign: "center", marginBottom: "32px" }}>
          <h1 style={{ fontSize: "48px", color: "#fbbf24" }}>260,840,972</h1>
          <h2 style={{ fontSize: "32px" }}>КОРИСТУВАЧІВ ДОВІРЯЮТЬ НАМ</h2>
          <div className="input-container" style={{ marginTop: "16px", display: "flex", justifyContent: "center" }}>
            <input type="text" placeholder="Ел. пошта/номер телефону" style={{ backgroundColor: "#2d3748", color: "white", padding: "8px", border: "none", borderRadius: "4px 0 0 4px", width: "256px" }} />
            <button style={{ backgroundColor: "#fbbf24", color: "black", padding: "8px 16px", border: "none", borderRadius: "0 4px 4px 0", cursor: "pointer" }}>Почати</button>
          </div>
          <div className="continue-container" style={{ marginTop: "16px", display: "flex", justifyContent: "center", alignItems: "center" }}>
            <span>Або продовжуйте через</span>
            <i className="fab fa-google" style={{ fontSize: "24px", marginLeft: "8px" }}></i>
            <i className="fab fa-apple" style={{ fontSize: "24px", marginLeft: "8px" }}></i>
          </div>
          <div className="download-container" style={{ marginTop: "16px", display: "flex", justifyContent: "center", alignItems: "center" }}>
            <span>Завантажте застосунок</span>
            <i className="fas fa-qrcode" style={{ fontSize: "24px", marginLeft: "8px" }}></i>
          </div>
        </div>
        <div className="right-section" style={{ backgroundColor: "#2d3748", padding: "16px", borderRadius: "8px", width: "100%", maxWidth: "400px" }}>
          <div className="header" style={{ display: "flex", justifyContent: "space-between", borderBottom: "1px solid #4a5568", paddingBottom: "8px", marginBottom: "8px" }}>
            <span style={{ fontSize: "18px", fontWeight: "bold" }}>Популярно</span>
            <span style={{ fontSize: "18px", fontWeight: "bold" }}>Нові лістинги</span>
            <span style={{ fontSize: "18px", fontWeight: "bold" }}>Усі монети (350+)</span>
          </div>
          <div className="coin-row" style={{ display: "flex", justifyContent: "space-between", marginBottom: "8px" }}>
            <span>BTC Bitcoin</span>
            <span>$96,274.22</span>
            <span className="change" style={{ color: "#e53e3e" }}>-0.20%</span>
          </div>
          <div className="coin-row" style={{ display: "flex", justifyContent: "space-between", marginBottom: "8px" }}>
            <span>ETH Ethereum</span>
            <span>$2,795.61</span>
            <span className="change positive" style={{ color: "#38a169" }}>+3.99%</span>
          </div>
          <div className="coin-row" style={{ display: "flex", justifyContent: "space-between", marginBottom: "8px" }}>
            <span>BNB BNB</span>
            <span>$667.71</span>
            <span className="change positive" style={{ color: "#38a169" }}>+1.82%</span>
          </div>
          <div className="coin-row" style={{ display: "flex", justifyContent: "space-between", marginBottom: "8px" }}>
            <span>XRP XRP</span>
            <span>$2.57</span>
            <span className="change" style={{ color: "#e53e3e" }}>-0.43%</span>
          </div>
          <div className="coin-row" style={{ display: "flex", justifyContent: "space-between", marginBottom: "8px" }}>
            <span>SOL Solana</span>
            <span>$171.17</span>
            <span className="change" style={{ color: "#e53e3e" }}>-0.29%</span>
          </div>
          <div className="header" style={{ display: "flex", justifyContent: "space-between", borderBottom: "1px solid #4a5568", paddingBottom: "8px", marginBottom: "8px" }}>
            <span style={{ fontSize: "18px", fontWeight: "bold" }}>Новини</span>
            <span style={{ fontSize: "18px", fontWeight: "bold" }}>Переглянути всі новини</span>
          </div>
          <div className="news-item" style={{ display: "flex", marginBottom: "8px" }}>
            <p>Генеральний директор Bybit закликає xExh переправити свою позицію щодо зниження коштів</p>
          </div>
          <div className="news-item" style={{ display: "flex", marginBottom: "8px" }}>
            <p>Підозрювана інституційна адреса бере участь у значних позабіржових транзакціях із Bybit</p>
          </div>
          <div className="news-item" style={{ display: "flex", marginBottom: "8px" }}>
            <p>Платформа закликають посилити контроль ризиків у фондах xExh</p>
          </div>
          <div className="news-item" style={{ display: "flex", marginBottom: "8px" }}>
            <p>Bitdeer збільшує авариу Bitcoin на 50 BTC</p>
          </div>
        </div>
      </main>
      <footer style={{ padding: "32px", textAlign: "center" }}>
        <p style={{ fontSize: "24px", fontWeight: "bold" }}>Торгуйте на ходу. Будь-де, будь-коли.</p>
      </footer>
    </div>
  );
};

export default HomePage;
