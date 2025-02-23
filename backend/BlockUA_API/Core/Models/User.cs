using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class User
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public string Password { get; set; }

    public bool Admin { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId WalletId { get; set; }

    public User(string username, string email, string avatarUrl, string password)
    {
        Id = new ObjectId();
        Username = username;
        Email = email;
        AvatarUrl = avatarUrl;
        Password = password;
        Admin = false;
    }

    public User(ObjectId id, string username, string email, string avatarUrl, string password, bool admin)
    {
        Id = id;
        Username = username;
        Email = email;
        AvatarUrl = avatarUrl;
        Password = password;
        Admin = admin;
    }

    public void setWallet(ObjectId walletId)
    {
        WalletId = walletId;
    }
    

    public object ToDtoString()
    {
        return new
        {
            Id = Id.ToString(),
            Username,
            Email,
            AvatarUrl
        };
    }

    public object ToDto()
    {
        return new
        {
            Id,
            Username,
            Email,
            AvatarUrl
        };
    }
}