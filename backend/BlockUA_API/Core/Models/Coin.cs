using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Coin
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    //public double TotalCost { get; set; }
    //public double? Capitalization { get; set; }

    public List<ExchangeRate> ExchangeRates = [];

    public Coin(string name, double totalCost)
    {
        Id = new ObjectId();
        Name = name;
        //TotalCost = totalCost;
    }

    // public Coin(string name, double totalCost, double capitalization)
    // {
    //     Id = new ObjectId();
    //     Name = name;
    //     TotalCost = totalCost;
    //     Capitalization = capitalization;
    // }
    
    public object ToDtoString()
    {
        return new
        {
            Id = Id.ToString(),
            Name,
            //TotalCost,
            //Capitalization,
            ExchangeRates = ExchangeRates.Select(rate => rate.ToDtoString()).ToArray()
        };
    }

    public object ToDto()
    {
        return new
        {
            Id,
            Name,
            //TotalCost,
            //Capitalization,
            ExchangeRates = ExchangeRates.Select(rate => rate.ToDto()).ToArray()
        };
    }
}