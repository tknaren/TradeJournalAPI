namespace TradeJournalAPI.Models
{
    public class TradeJournalDBSettings : ITradeJournalDBSettings
    {
        public string WeeklyScanCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
