﻿namespace TradeJournalAPI.Models
{
    public interface ITradeJournalDBSettings
    {
        public string WeeklyScanCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
