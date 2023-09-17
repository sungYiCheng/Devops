using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice.DTO;
using practice.Models;
using practice.Parameter;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        private readonly BbtestContext _db;

        public OtherController(BbtestContext bbtestContext)
        {
            _db = bbtestContext;
        }

        //[HttpGet]
        public IEnumerable<Bbtable> Get([FromQuery] QueryParam queryParam)
        {
            var result = _db.Bbtables.ToList();

            if (!string.IsNullOrEmpty(queryParam.aName))
            {
                result = result.Where(x => x.Aname == queryParam.aName).ToList();
            };

            if (!string.IsNullOrEmpty(queryParam.bName))
            {
                result = result.Where(x => x.Bname == queryParam.bName).ToList();
            };

            return result;
        }

        //[HttpGet]
        public IEnumerable<Bbtable> Get([FromQuery] string? aName, string? bName)
        {
            var result = _db.Bbtables.ToList();

            if (!string.IsNullOrEmpty(aName))
            {
                result = result.Where(x => x.Aname == aName).ToList();
            };

            if (!string.IsNullOrEmpty(bName))
            {
                result = result.Where(x => x.Bname == bName).ToList();
            };

            return result;
        }

        [HttpGet("From/{id2}")]
        public List<int> Get([FromQuery] int id
            ,[FromRoute] int id2
           ,[FromBody] string id3
 //           , [FromForm] int id4
            )
        {
            List<int> result = new List<int>();
            result.Add(id);
            result.Add(id2);
            result.Add(Convert.ToInt32(id3));
            //result.Add(id4);

            return result;
        }


        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        public BbtestDTOSelect Get([FromRoute]int id)
        {
            return _db.Bbtables.Where(x => x.Aa == id).Select(x => new BbtestDTOSelect
            {
                Aa = x.Aa,
                Bb = x.Bb,
                AAName = "THis is test A",
                BBName = "THis is test B",
            }).SingleOrDefault();
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

                //_db.Bbtables.Entry(value).State = EntityState.Modified;

                // _db.Bbtables.Update(value);

                // 自動mapping 傳入的value
                _db.Bbtables.Update(value).CurrentValues.SetValues(value);

                _db.SaveChanges();

                return CreatedAtAction(nameof(Get), new { AAA = value.Aa }, value);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"{ex.Message}, {ex.InnerException?.Message}");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Put(int id, [FromBody] JsonPatchDocument value)
        {
            try
            {
                var update = _db.Bbtables.FirstOrDefault(x => x.Aa == id);

                if ( update == null)
                {
                    return NotFound("無此資料");
                }

                value.ApplyTo(update);

                _db.SaveChanges();

                return Ok();
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

        //[HttpDelete("{id}")]
        public IActionResult Delete(int id, int all = default)
        {
            try
            {
                var result = _db.Bbtables.Where(x => x.Aa == id);

                if (result == null)
                {
                    return NotFound();
                }

                _db.Bbtables.RemoveRange(result);
                _db.SaveChanges();

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"{ex.Message}, {ex.InnerException?.Message}");
            }
        }

        //[HttpDelete("{id}")]
        public IActionResult Delete(string listStr)
        {
            try
            {
                if (string.IsNullOrEmpty(listStr))
                {
                    return BadRequest("輸入列表有誤");
                }

                List<int> deleteList = JsonConvert.DeserializeObject<List<int>>(listStr);

                if ((deleteList == null) || (deleteList.Count == 0))
                {
                    return NotFound();
                }

                var delete = _db.Bbtables.Where(x => deleteList.Contains(x.Aa));

                _db.Bbtables.RemoveRange(delete);
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
