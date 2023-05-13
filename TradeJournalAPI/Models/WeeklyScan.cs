using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TradeJournalAPI.Models
{
    [BsonIgnoreExtraElements]
    public class WeeklyScan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;
        [BsonElement("date")]
        public string date { get; set; }
        [BsonElement("instrument")]
        public string? instrument { get; set; }
        [BsonElement("currentPrice")]
        public double currentPrice { get; set; }
        [BsonElement("isTrending")]
        public bool isTrending { get; set; }
        [BsonElement("weeklyTrend")]
        public string? weeklyTrend { get; set; }
        [BsonElement("dailyTrend")]
        public string? dailyTrend { get; set; }
        [BsonElement("srLevels")]
        public SRLevels? srLevels { get; set; }
        [BsonElement("ema")]
        public EMA? ema { get; set; }
        [BsonElement("potentialTrade")]
        public PotentialTrade? potentialTrade { get; set; }

    }

    

    public class EMA
    {
        [BsonElement("fast")]
        public double fast { get; set; }
        [BsonElement("slow")]
        public double slow { get; set; }
    }

    public class PotentialTrade
    {
        [BsonElement("direction")]
        public string? direction { get; set; }
        [BsonElement("entry")]
        public double entry { get; set; }
        [BsonElement("sl")]
        public double sl { get; set; }
        [BsonElement("stake")]
        public double stake { get; set; }
        [BsonElement("slPips")]
        public int slPips { get; set; }
        [BsonElement("tp1Pips")]
        public int tp1Pips { get; set; }
        [BsonElement("tp2Pips")]
        public int tp2Pips { get; set; }
        [BsonElement("tp3Pips")]
        public int tp3Pips { get; set; }
        [BsonElement("rr1")]
        public string? rr1 { get; set; }
        [BsonElement("rr2")]
        public string? rr2 { get; set; }
        [BsonElement("rr3")]
        public string? rr3 { get; set; }

    }
}
