using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class ExchangeRate
{
    public ObjectId Id { get; set; }
    public double Cost { get; set; }
    public DateTime СoinRateTimestamp { get; set; }

    public ExchangeRate(double cost, DateTime coinRateTimestamp)
    {
        Id = new ObjectId();
        Cost = cost; 
        СoinRateTimestamp = coinRateTimestamp;
    }

    public object ToDtoString()
    {
        return new
        {
            Id = Id.ToString(),
            Cost,
            СoinRateTimestamp
        };
    }

    public object ToDto()
    {
        return new
        {
            Id,
            Cost,
            СoinRateTimestamp
        };
    }
}