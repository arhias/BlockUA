import React, { useEffect } from "react";
import "../css/TradingPage.css";

const TradingPage: React.FC = () => {
  useEffect(() => {
    const orderBookData = [
      { price: "96,327.00", amount: "0.00007" },
      { price: "96,326.99", amount: "0.04150" },
      { price: "96,326.98", amount: "0.00012" },
      { price: "96,326.37", amount: "0.00001" },
      { price: "96,326.00", amount: "0.00006" },
      { price: "96,325.99", amount: "0.00006" },
      { price: "96,325.98", amount: "0.00006" },
      { price: "96,325.97", amount: "0.00006" },
      { price: "96,325.96", amount: "0.00006" },
      { price: "96,325.95", amount: "0.00006" },
      { price: "96,325.94", amount: "0.00006" },
      { price: "96,325.93", amount: "0.00006" },
      { price: "96,325.92", amount: "0.00006" },
      { price: "96,325.91", amount: "0.00006" },
      { price: "96,325.90", amount: "0.00006" },
    ];

    const marketTradesData = [
      { price: "96,326.00", amount: "0.00017", time: "08:50:08" },
      { price: "96,325.99", amount: "0.00027", time: "08:50:07" },
      { price: "96,325.98", amount: "0.00012", time: "08:50:06" },
      { price: "96,325.97", amount: "0.00001", time: "08:50:05" },
      { price: "96,325.96", amount: "0.00006", time: "08:50:04" },
      { price: "96,325.95", amount: "0.00006", time: "08:50:03" },
      { price: "96,325.94", amount: "0.00006", time: "08:50:02" },
      { price: "96,325.93", amount: "0.00006", time: "08:50:01" },
      { price: "96,325.92", amount: "0.00006", time: "08:50:00" },
      { price: "96,325.91", amount: "0.00006", time: "08:49:59" },
      { price: "96,325.90", amount: "0.00006", time: "08:49:58" },
    ];

    const orderBookElement = document.getElementById("order-book");
    orderBookData.forEach((order) => {
      const orderElement = document.createElement("div");
      orderElement.textContent = `${order.price} | ${order.amount}`;
      orderBookElement?.appendChild(orderElement);
    });

    const marketTradesElement = document.getElementById("market-trades");
    marketTradesData.forEach((trade) => {
      const tradeElement = document.createElement("div");
      tradeElement.textContent = `${trade.price} | ${trade.amount} | ${trade.time}`;
      marketTradesElement?.appendChild(tradeElement);
    });
  }, []);

  return (
    <div className="main-container">
      <div className="sidebar">
        <div className="header">
          <h2>BTC/USDT</h2>
          <span className="text-green-500">96,326.00</span>
        </div>
        <div className="details">
          <div>
            Зміна за 24 год: <span className="text-red-500">-120.00</span>
          </div>
          <div>Обсяг за 24 год(BTC): 10,167.59</div>
          <div>Обсяг за 24 год(USDT): 981,482.14</div>
          <div>Теги токенів: POW | Payments | Price Protection</div>
        </div>
        <div className="order-book">
          <h3>Книга ордерів</h3>
          <div>Ціна (USDT) | Сума (BTC)</div>
          <div id="order-book" className="text-red-500"></div>
        </div>
      </div>
      <div className="content">
        <div className="header">
          <h2>Графік</h2>
          <div className="buttons">
            <button className="btn">Купити</button>
            <button className="btn">Продати</button>
          </div>
        </div>
        <img
          src="https://storage.googleapis.com/a1aa/image/JnGNvgssWrz2h1OYyA-J_VMf9DfAva2geAwiXQlRzyE.jpg"
          alt="Graph showing BTC/USDT price changes"
          className="graph"
        />
        <div className="market-trades">
          <h3>Угоди на ринку</h3>
          <div>Ціна (USDT) | Сума (BTC) | Час</div>
          <div id="market-trades" className="text-green-500"></div>
        </div>
      </div>
    </div>
  );
};

export default TradingPage;
