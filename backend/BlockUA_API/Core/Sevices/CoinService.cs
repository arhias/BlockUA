using Core.Interfaces;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Sevices;

public class CoinService(BlockUaDbContext context, PasswordHasher hasher) : ICoinService
{
    public async Task<Response> CreateCoin(string name, double totalCost = 0, double? capitalization = null)
    {
        Coin coin = new Coin(name, totalCost);
        if (capitalization != null) coin.Capitalization = capitalization;
        await context.Coins.InsertOneAsync(coin);
        return new Response(200, "Coin created successfully");
    }

    public async Task<Response> DeleteCoin(string coinId)
    {
        var coin = await context.Coins.Find(c => c.Id.ToString().Equals(coinId)).FirstOrDefaultAsync();
        if (coin == null) return new Response(404, "Coin not found");
        await context.Coins.DeleteOneAsync(c => c.Id.Equals(coin.Id));
        return new Response(200, "Coin deleted successfully");
    }

    public async Task<Response> AddExchangeRate(string coinId, double cost, DateTime date)
    {
        var coin = await context.Coins.Find(c => c.Id.ToString().Equals(coinId)).FirstOrDefaultAsync();
        if (coin == null) return new Response(404, "Coin not found");
        coin.ExchangeRates.Add(new ExchangeRate(cost, date));
        await context.Coins.ReplaceOneAsync(c => c.Id.Equals(coin.Id), coin);
        return new Response(200, "Successfully added");
    }

    public async Task<Response> GetTotalCount(string coinId)
    {
        var coin = await context.Coins.Find(c => c.Id.ToString().Equals(coinId)).FirstOrDefaultAsync();
        if (coin == null) return new Response(404, "Coin not found");
        var wallets = context.Wallets.Find(new BsonDocument()).ToList();
        double sum = 0;
        foreach (var wallet in wallets)
        {
            if (wallet.Coins.TryGetValue(coinId, out var value)) sum += value;
        }

        return new Response(200, "Successfully", sum);
    }

    public async Task<Response> GetCoinCost(string coinId)
    {
        Coin coin = await context.Coins.Find(c => c.Id.ToString().Equals(coinId)).FirstOrDefaultAsync();
        if (coin == null) return new Response(404, "Coin not found");
        return new Response(200, "Successfully", coin.ExchangeRates.Last());
    }

    public async Task<Response> GetCoinInfo(string coinId)
    {
        Coin coin = await context.Coins.Find(c => c.Id.ToString().Equals(coinId)).FirstOrDefaultAsync();
        if (coin == null) return new Response(404, "Coin not found");
        return new Response(200, "Successfully", coin.ToDtoString());
    }

    public async Task<Response> GetCoins()
    {
        List<Coin> coins = context.Coins.Find(new BsonDocument()).ToList();
        if (coins == null) return new Response(404, "Coins not found");
        return new Response(200, "Successfully", coins.Select(c => c.ToDtoString()));
    }
}