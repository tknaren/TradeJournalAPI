using TradeJournalAPI.Models;
using MongoDB.Driver;

namespace TradeJournalAPI.Services
{
    public interface IWeeklyScanService
    {
        List<WeeklyScan> Get();
        WeeklyScan Get(string id);
        WeeklyScan Create(WeeklyScan item);
        void Update(string id, WeeklyScan item);
        void Remove(string id);

    }

    public class WeeklyScanService : IWeeklyScanService
    {
        private readonly IMongoCollection<WeeklyScan> _weeklyScan;

        public WeeklyScanService(ITradeJournalDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _weeklyScan = database.GetCollection<WeeklyScan>(settings.WeeklyScanCollectionName);
        }

        public WeeklyScan Create(WeeklyScan weeklyScan)
        {
            _weeklyScan.InsertOne(weeklyScan);
            return weeklyScan;
        }

        public List<WeeklyScan> Get()
        {
            return _weeklyScan.Find(weeklyScan => true).ToList();
        }

        public WeeklyScan Get(string id)
        {
            return _weeklyScan.Find(weeklyScan => weeklyScan.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _weeklyScan.DeleteOne(weeklyScan => weeklyScan.id == id);
        }

        public void Update(string id, WeeklyScan item)
        {
            _weeklyScan.ReplaceOne(weeklyScan => weeklyScan.id == id, item);
        }
    }
}
