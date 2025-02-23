import React, { useState } from 'react';
import '../css/RegistrationPage.css'; 

const RegistrationPage: React.FC = () => {
    const [email, setEmail] = useState('');
    const [termsAccepted, setTermsAccepted] = useState(false);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        console.log(`Email: ${email}, Terms Accepted: ${termsAccepted}`);
    };

    return (
        <div className="container">
            <div className="logo">
                <img
                    src=""
                    alt="Binance logo"
                />
            </div>
            <h1>Вітаємо на Binance</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="email">Ел. пошта/номер телефону</label>
                    <input
                        type="text"
                        id="email"
                        name="email"
                        placeholder="Ел. адреса/телефон (без коду країни)"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className="checkbox-label">
                    <input
                        type="checkbox"
                        id="terms"
                        name="terms"
                        checked={termsAccepted}
                        onChange={(e) => setTermsAccepted(e.target.checked)}
                    />
                    <label htmlFor="terms">
                        Створюючи акаунт, я приймаю Умови користування і Політику конфіденційності Binance.
                    </label>
                </div>
                <button type="submit">Далі</button>
            </form>
            <div className="divider">
                <span>або</span>
            </div>
            <div className="social-buttons">
                <button className="social-button google">
                    <i className="fab fa-google"></i> Продовжити з Google
                </button>
                <button className="social-button apple">
                    <i className="fab fa-apple"></i> Продовжити з Apple
                </button>
                <button className="social-button telegram">
                    <i className="fab fa-telegram"></i> Продовжити з Telegram
                </button>
            </div>
            <div className="footer">
                <a href="#">Зареєструвати акаунт організації</a> або <a href="#">ввійти</a>
            </div>
            <div className="support-button">
                <i className="fas fa-headset"></i>
            </div>
        </div>
    );
};

export default RegistrationPage;
