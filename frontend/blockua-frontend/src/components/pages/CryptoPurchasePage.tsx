import React, { useState } from 'react';

interface Crypto {
  name: string;
  price: string;
  change: string;
  changeClass: string;
  logo: string;
}

const CryptoPurchasePage: React.FC = () => {
  const cryptos: Crypto[] = [
    { name: 'BNB', price: '$666.74', change: '+1.61%', changeClass: 'text-green-500', logo: 'https://storage.googleapis.com/a1aa/image/1d2GYXm5qFJpkaN8Jsn91jBwdtli9IHFsc7uGJ41qe0.jpg' },
    { name: 'BTC', price: '$96,341.33', change: '-0.01%', changeClass: 'text-red-500', logo: 'https://storage.googleapis.com/a1aa/image/09_12v5zxBYKRtJ4NV5ZT6ulO46g6CuyeS_ZvysL2yw.jpg' },
    { name: 'ETH', price: '$2,789.89', change: '+3.82%', changeClass: 'text-green-500', logo: 'https://storage.googleapis.com/a1aa/image/f5r5DWURynAZCo2ofqV7ST5zMdSYl6sXIXzrLafegx0.jpg' },
    { name: 'SOL', price: '$171.41', change: '+0.16%', changeClass: 'text-green-500', logo: 'https://storage.googleapis.com/a1aa/image/vfuYlSIX3I0BZJ_4pa3rTPfCbRkvfpd6uD0aaJXzZW8.jpg' },
    { name: 'XRP', price: '$2.56', change: '-0.64%', changeClass: 'text-red-500', logo: 'https://storage.googleapis.com/a1aa/image/OhLFKya-j65h7H56wVblqHKsnKed8BwN0X8q7ebjWus.jpg' }
  ];

  return (
    <div className="bg-gray-800 text-white font-sans">
      <header className="flex justify-between items-center p-4 bg-gray-700">
        <div className="left">
          <img alt="Binance logo" src="https://storage.googleapis.com/a1aa/image/-NLraJC3OWFC550Nmzq3W9mtwCK9r6NUEDyltiSLkeo.jpg" className="h-10" />
          <nav>
            <a href="#" className="mr-4 hover:text-orange-400">Купівля криптовалют</a>
            <a href="#" className="mr-4 hover:text-orange-400">Ринки</a>
            <a href="#" className="hover:text-orange-400">Торгіля</a>
          </nav>
        </div>
        <div className="right">
          <i className="fas fa-user-circle text-3xl"></i>
        </div>
      </header>

      <main className="p-8">
        <h1 className="text-3xl font-bold mb-8">Купівля криптовалют</h1>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8">
          <div className="card bg-gray-700 p-6 rounded-lg">
            <h2 className="text-xl mb-4">Популярні криптовалюти</h2>
            <ul id="crypto-list">
              {cryptos.map((crypto) => (
                <li key={crypto.name} className="flex justify-between items-center py-2">
                  <div className="flex items-center space-x-2">
                    <img alt={crypto.name} className="h-5 w-5" src={crypto.logo} />
                    <span>{crypto.name}</span>
                  </div>
                  <div className="flex items-center space-x-2">
                    <span>{crypto.price}</span>
                    <span className={crypto.changeClass}>{crypto.change}</span>
                  </div>
                </li>
              ))}
            </ul>
          </div>

          <div className="card bg-gray-700 p-6 rounded-lg">
            <div className="tabs mb-4">
              <button className="active text-white pb-2 border-b-2 border-orange-400 mr-4">Купівля</button>
              <button className="text-white pb-2 hover:border-b-2 hover:border-orange-400">Продаж</button>
            </div>
            <div className="input-group bg-gray-600 p-4 rounded-lg mb-4">
              <div className="flex justify-between items-center">
                <span>Списати</span>
                <span>3,000 - 1,350,000</span>
              </div>
              <div className="flex justify-between items-center mt-2">
                <span className="text-blue-300">$</span>
                <span>ARS</span>
              </div>
            </div>
            <div className="input-group bg-gray-600 p-4 rounded-lg mb-4">
              <div className="flex justify-between items-center">
                <span>Отримати</span>
                <span>0</span>
              </div>
              <div className="flex justify-between items-center mt-2">
                <span className="text-red-500">1000CAT</span>
              </div>
            </div>
            <button className="w-full bg-orange-400 text-black py-3 rounded-lg">Верифікація особи</button>
          </div>
        </div>
      </main>
    </div>
  );
};

export default CryptoPurchasePage;
