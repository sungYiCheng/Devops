using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly BbtestContext _db;

        public CRUDController(BbtestContext bbtestContext)
        {
            _db = bbtestContext;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Bbtable>> Get()
        {
            return _db.Bbtables;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Bbtable> Get(int id)
        {
            var result = _db.Bbtables.FirstOrDefault(x => x.Aa == id);
            //var result = _ontext.Bbtables.Where(x => x.Aa == id);

            return result != null ? result : NotFound($"無此 AAA {id}");
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
                var result = _db.Bbtables.FirstOrDefault(x => x.Aa == id);

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
