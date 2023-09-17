using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X509;
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
            try
            {
                var result = from table in _db.Bbtables
                             where table.Aa == id
                             select table;

                result = _db.Bbtables.Where(x => x.Aa == id);

                result = (from table in _db.Bbtables select table).Where(x => x.Aa == id);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<Bbtable> Post([FromBody] Bbtable value)
        {
            try
            {
                _db.Bbtables.Add(value);
                _db.SaveChanges();

                return CreatedAtAction(nameof(Get), new { AAA = value.Aa }, value);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}, {ex.InnerException?.Message}");
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bbtable value)
        {
            try
            {
                if (id != value.Aa)
                {
                    return BadRequest($"id not equal");
                }

                _db.Bbtables.Entry(value).State = EntityState.Modified;
                _db.SaveChanges();

                return CreatedAtAction(nameof(Get), new { AAA = value.Aa }, value);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"{ex.Message}, {ex.InnerException?.Message}");
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = (from table in _db.Bbtables select table).Where(x => x.Aa == id).First();

                if (result == null)
                {
                    return NotFound();
                }

                _db.Bbtables.Remove(result);
                _db.SaveChanges();

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"{ex.Message}, {ex.InnerException?.Message}");
            }

        }
    }
}
