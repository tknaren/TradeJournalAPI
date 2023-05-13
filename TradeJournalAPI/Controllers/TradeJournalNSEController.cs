using Microsoft.AspNetCore.Mvc;
using TradeJournalAPI.Models;
using TradeJournalAPI.Services;

namespace TradeJournalAPI.Controllers
{
    public class TradeJournalNSEController : Controller
    {
        private readonly ITradeJournalNSEService tradeJournalNSEService;

        public TradeJournalNSEController(ITradeJournalNSEService tradeJournalNSEService)
        {
            this.tradeJournalNSEService = tradeJournalNSEService;
        }

        // GET: api/<TradeJournalNSEController>
        [HttpGet]
        public ActionResult<List<TradeJournalNSE>> Get()
        {
            return tradeJournalNSEService.Get();
        }

        // GET api/<TradeJournalNSEController>/5
        [HttpGet("{id}")]
        public ActionResult<TradeJournalNSE> Get(string id)
        {
            var weeklyScanItem = tradeJournalNSEService.Get(id);

            if (weeklyScanItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            return weeklyScanItem;
        }

        // POST api/<TradeJournalNSEController>
        [HttpPost]
        public ActionResult<TradeJournalNSE> Post([FromBody] TradeJournalNSE weeklyScanItem)
        {
            tradeJournalNSEService.Create(weeklyScanItem);

            return CreatedAtAction(nameof(Get), new { id = weeklyScanItem.id }, weeklyScanItem);
        }

        // PUT api/<TradeJournalNSEController>/5
        [HttpPut("{id}")]
        public ActionResult<TradeJournalNSE> Put(string id, [FromBody] TradeJournalNSE weeklyScanItem)
        {
            var existingTradeJournalNSEItem = tradeJournalNSEService.Get(id);

            if (existingTradeJournalNSEItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            tradeJournalNSEService.Update(id, weeklyScanItem);

            return NoContent();
        }

        // DELETE api/<TradeJournalNSEController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingTradeJournalNSEItem = tradeJournalNSEService.Get(id);

            if (existingTradeJournalNSEItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            tradeJournalNSEService.Remove(existingTradeJournalNSEItem.id);

            return Ok($"TradeJournalNSE item with id = {id} deleted");
        }
    }
}
