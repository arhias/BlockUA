import React, { useState } from 'react';

const AccountPage: React.FC = () => {
    const [balance, setBalance] = useState(0.00);  // Placeholder for dynamic balance
    const [pnl, setPnl] = useState(0.00);  // Placeholder for dynamic PNL

    return (
        <div>
            <header>
                <div className="logo">
                    <img
                        src="https://storage.googleapis.com/a1aa/image/sJPTw4QrnXj3C0tz2azjXFYj8Q72S5ll65puWmIR-vo.jpg"
                        alt="Binance logo"
                        width="40"
                        height="40"
                    />
                    <span className="text-yellow-500 font-bold text-lg">BINANCE</span>
                </div>
                <nav>
                    <a href="#">Купівля криптовалют</a>
                    <a href="#">Ринки</a>
                    <a href="#">Торгівля</a>
                    <i className="fas fa-user-circle"></i>
                </nav>
            </header>
            <main>
                <div className="profile">
                    <img
                        src="https://storage.googleapis.com/a1aa/image/1oGPS6JAOkwP9vScFSX8LDSnqZ3gxu2N5V1in1Bok-w.jpg"
                        alt="Default user avatar"
                        width="50"
                        height="50"
                    />
                    <div>
                        <div className="text-lg font-bold">User-b84fb</div>
                        <div className="text-gray-400">UID 1077548911</div>
                    </div>
                </div>
                <div className="balance-card">
                    <div className="title">Орієнтовний баланс</div>
                    <div className="balance">{balance} BTC</div>
                    <div className="details">~ {balance * 10000} $</div>  {/* Example conversion */}
                    <div className="details">PNL за сьогодні: + {pnl} $ ({pnl}%)</div>
                    <div className="actions">
                        <button>Депозит</button>
                        <button>Зняття</button>
                        <button>Купівля криптовалюти</button>
                    </div>
                </div>
            </main>
        </div>
    );
};

export default AccountPage;
