using Core.Models;
using MongoDB.Driver;

namespace Core;

public class BlockUaDbContext
{
    private readonly IMongoDatabase _database;

    public BlockUaDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Coin> Coins => _database.GetCollection<Coin>("Coins");
    public IMongoCollection<Wallet> Wallets => _database.GetCollection<Wallet>("Wallets");
    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
}