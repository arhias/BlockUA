using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Wallet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId UserId { get; set; }

    public Dictionary<string, double> Coins = new Dictionary<string, double>();

    public Wallet(ObjectId userId)
    {
        Id = new ObjectId();
        UserId = userId;
    }

    public void AddCoin(string coinId, double count)
    {
        if (!Coins.TryAdd(coinId, count))
        {
            if (Coins[coinId] + count > 0) Coins[coinId] += count;
        }
    }

    public void DeleteCoin(string coinId)
    {
        Coins.Remove(coinId);
    }

    public double GetCoin(string coinId)
    {
        if (Coins.TryGetValue(coinId, out var coin)) return coin;
        else return -1;
    }
}