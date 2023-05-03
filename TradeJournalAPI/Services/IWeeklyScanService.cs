using TradeJournalAPI.Models;

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
}
