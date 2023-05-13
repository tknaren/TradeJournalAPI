using MongoDB.Driver;
using TradeJournalAPI.Models;

namespace TradeJournalAPI.Services
{
    public interface IWeeklyScanNSEService
    {
        List<WeeklyScanNSE> Get();
        WeeklyScanNSE Get(string id);
        WeeklyScanNSE Create(WeeklyScanNSE item);
        void Update(string id, WeeklyScanNSE item);
        void Remove(string id);
    }
    public class WeeklyScanNSEService : IWeeklyScanNSEService
    {
        private readonly IMongoCollection<WeeklyScanNSE> _weeklyScanNSE;

        public WeeklyScanNSEService(ITradeJournalDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _weeklyScanNSE = database.GetCollection<WeeklyScanNSE>(settings.WeeklyScanNSECollectionName);
        }

        public WeeklyScanNSE Create(WeeklyScanNSE weeklyScanNSE)
        {
            _weeklyScanNSE.InsertOne(weeklyScanNSE);
            return weeklyScanNSE;
        }

        public List<WeeklyScanNSE> Get()
        {
            return _weeklyScanNSE.Find(weeklyScanNSE => true).ToList();
        }

        public WeeklyScanNSE Get(string id)
        {
            return _weeklyScanNSE.Find(weeklyScanNSE => weeklyScanNSE.id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _weeklyScanNSE.DeleteOne(weeklyScanNSE => weeklyScanNSE.id == id);
        }

        public void Update(string id, WeeklyScanNSE item)
        {
            _weeklyScanNSE.ReplaceOne(weeklyScanNSE => weeklyScanNSE.id == id, item);
        }
    }
}
