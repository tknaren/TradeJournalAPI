using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TradeJournalAPI.Models
{
    [BsonIgnoreExtraElements]
    public class TradeJournalNSE
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; } = String.Empty;
        public string? ticker { get; set; }
        public string? strategy { get; set; }
        public string? direction { get; set; }
        public string? entryDate { get; set; }
        public string? entryTime { get; set; }
        public decimal qty { get; set; }
        public decimal entryOrderPrice { get; set; }
        public decimal entryFilledPrice { get; set; }
        public decimal entrySlippage { get; set; }
        public decimal entryCommission { get; set; }
        public decimal entryTotalCost { get; set; }
        public decimal positionSize { get; set; }
        public decimal entryDayHigh { get; set; }
        public decimal entryDayLow { get; set; }
        public string? entryGrade { get; set; }
        public string? exitDate { get; set; }
        public string? exitTime { get; set; }
        public decimal exitPrice { get; set; }
        public decimal exitFilledPrice { get; set; }
        public decimal exitSlippage { get; set; }
        public decimal exitCommission { get; set; }
        public decimal exitTotalCost { get; set; }
        public decimal exitDayHigh { get; set; }
        public decimal exitDayLow { get; set; }
        public string? exitGrade { get; set; }
        public string? profitLoss { get; set; }
        public decimal profitLossInPercent { get; set; }
        public string? tradeGrade { get; set; }
        public string? reasonForEntry { get; set; }
        public string? reasonForExit { get; set; }
        public string? postTradeAnalysis { get; set; }
        public string? chart { get; set; }
    }
}
