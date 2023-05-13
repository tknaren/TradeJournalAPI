using MongoDB.Bson.Serialization.Attributes;

namespace TradeJournalAPI.Models
{
    public class SRLevels
    {
        [BsonElement("s1")]
        public double s1 { get; set; }
        [BsonElement("s2")]
        public double s2 { get; set; }
        [BsonElement("s3")]
        public double s3 { get; set; }
        [BsonElement("r1")]
        public double r1 { get; set; }
        [BsonElement("r2")]
        public double r2 { get; set; }
        [BsonElement("r3")]
        public double r3 { get; set; }

    }
}
