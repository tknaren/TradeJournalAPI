using TradeJournalAPI.Models;
using MongoDB.Driver;

namespace TradeJournalAPI.Services
{
    public interface ITradeJournalNSEService
    {
        List<TradeJournalNSE> Get();
        TradeJournalNSE Get(string id);
        TradeJournalNSE Create(TradeJournalNSE item);
        void Update(string id, TradeJournalNSE item);
        void Remove(string id);
    }

    public class TradeJournalNSEService
    {
        private readonly IMongoCollection<TradeJournalNSE> _tradeJournalNSE;

        public TradeJournalNSEService(ITradeJournalDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _tradeJournalNSE = database.GetCollection<TradeJournalNSE>(settings.TradeJournalNSECollectionName);
        }

        public TradeJournalNSE Create(TradeJournalNSE tradeJournalNSE)
        {
            _tradeJournalNSE.InsertOne(tradeJournalNSE);
            return tradeJournalNSE;
        }

        public List<TradeJournalNSE> Get()
        {
            return _tradeJournalNSE.Find(tradeJournalNSE => true).ToList();
        }

        public TradeJournalNSE Get(string id)
        {
            return _tradeJournalNSE.Find(tradeJournalNSE => tradeJournalNSE.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _tradeJournalNSE.DeleteOne(tradeJournalNSE => tradeJournalNSE.id == id);
        }

        public void Update(string id, TradeJournalNSE item)
        {
            _tradeJournalNSE.ReplaceOne(tradeJournalNSE => tradeJournalNSE.id == id, item);
        }
    }
}
