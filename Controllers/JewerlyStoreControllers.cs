
using Microsoft.AspNetCore.Mvc;
using core;

namespace core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JewerlyStoreController : ControllerBase
    {
        // רשימת תכשיטים לדוגמה
        private static readonly List<JewerlyStore> jewelry = new()
        {
            new JewerlyStore
            {
                Id = 1,
                Date = DateOnly.FromDateTime(DateTime.Today),
                Price = 1500,
                Summary = "gold"
            },
            new JewerlyStore
            {
                Id = 2,
                Date = DateOnly.FromDateTime(DateTime.Today),
                Price = 800,
                Summary = "silver"
            }
        };

        private static int nextId = 3;

        // GET - הצגת כל התכשיטים
        [HttpGet]
        public ActionResult<IEnumerable<JewerlyStore>> Get()
        {
            return Ok(jewelry);
        }

        // GET - הצגת תכשיט לפי מזהה
        [HttpGet("{id:int}")]
        public ActionResult<JewerlyStore> GetById(int id)
        {
            var item = jewelry.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST - הוספת תכשיט
        [HttpPost]
        public ActionResult<JewerlyStore> Post(JewerlyStore item)
        {
            item.Id = nextId++;
            jewelry.Add(item);

            return CreatedAtAction(
                nameof(GetById),
                new { id = item.Id },
                item
            );
        }

        // PUT - עדכון תכשיט קיים
        [HttpPut("{id:int}")]
        public ActionResult<JewerlyStore> Put(
            int id,
            JewerlyStore updatedItem)
        {
            var item = jewelry.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            item.Date = updatedItem.Date;
            item.Price = updatedItem.Price;
            item.Summary = updatedItem.Summary;

            return Ok(item);
        }

        // DELETE - מחיקת תכשיט
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = jewelry.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound();

            jewelry.Remove(item);

            return NoContent();
        }
    }
}
