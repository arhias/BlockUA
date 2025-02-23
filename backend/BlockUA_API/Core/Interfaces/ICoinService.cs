using Core.Models;

namespace Core.Interfaces;

public interface ICoinService
{
    Task<Response> CreateCoin(string name, double totalCost = 0, double? capitalization = null);
    Task<Response> DeleteCoin(string coinId);
    Task<Response> AddExchangeRate(string coinId, double cost, DateTime date);
    Task<Response> GetTotalCount(string coinId);
    Task<Response> GetCoinCost(string coinId);
    Task<Response> GetCoinInfo(string coinId);
    Task<Response> GetCoins();
    Task<Response> GetExchangeRates(string coinId);
}