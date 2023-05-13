using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TradeJournalAPI.Models
{
    public class WeeklyScanNSE
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;
        public string? weekEnding { get; set; }
        public WeeklyTradeScan[]? tradeScan { get; set; }
    }

    public class WeeklyTradeScan
    {
        public string? ticker { get; set; }
        public string? dmiTrend { get; set; }
        public decimal macd { get; set; }
        public decimal signal { get; set; }
        public decimal histogram { get; set; }
        public decimal impulse { get; set; }
        public string? candle { get; set; }
        public SRLevels? srLevel { get; set; }
    }


}
