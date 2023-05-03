using Microsoft.AspNetCore.Mvc;
using TradeJournalAPI.Models;
using TradeJournalAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradeJournalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyScanController : ControllerBase
    {
        private readonly IWeeklyScanService weeklyScanService;

        public WeeklyScanController(IWeeklyScanService weeklyScanService)
        {
            this.weeklyScanService = weeklyScanService;
        }

        // GET: api/<WeeklyScanController>
        [HttpGet]
        public ActionResult<List<WeeklyScan>> Get()
        {
            return weeklyScanService.Get();
        }

        // GET api/<WeeklyScanController>/5
        [HttpGet("{id}")]
        public ActionResult<WeeklyScan> Get(string id)
        {
            var weeklyScanItem = weeklyScanService.Get(id);

            if (weeklyScanItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            return weeklyScanItem;
        }

        // POST api/<WeeklyScanController>
        [HttpPost]
        public ActionResult<WeeklyScan> Post([FromBody] WeeklyScan weeklyScanItem)
        {
            weeklyScanService.Create(weeklyScanItem);

            return CreatedAtAction(nameof(Get), new { id = weeklyScanItem.id }, weeklyScanItem);
        }

        // PUT api/<WeeklyScanController>/5
        [HttpPut("{id}")]
        public ActionResult<WeeklyScan> Put(string id, [FromBody] WeeklyScan weeklyScanItem)
        {
            var existingWeeklyScanItem = weeklyScanService.Get(id);

            if (existingWeeklyScanItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            weeklyScanService.Update(id, weeklyScanItem);

            return NoContent();
        }

        // DELETE api/<WeeklyScanController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingWeeklyScanItem = weeklyScanService.Get(id);

            if (existingWeeklyScanItem == null)
            {
                return NotFound("Weekly Scan item not found");
            }

            weeklyScanService.Remove(existingWeeklyScanItem.id);

            return Ok($"WeeklyScan item with id = {id} deleted");
        }
    }
}
