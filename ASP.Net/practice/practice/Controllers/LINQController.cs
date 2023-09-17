using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using practice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LINQController : ControllerBase
    {
        private readonly BbtestContext _db;

        public LINQController(BbtestContext bbtestContext)
        {
            _db = bbtestContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Bbtable> Get()
        {
            return _db.Bbtables.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<Bbtable> Get(int id)
        {
            var result = from table in _db.Bbtables
                         where table.Aa == id
                         select table;

            result = _db.Bbtables.Where(x => x.Aa == id);

            return result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
