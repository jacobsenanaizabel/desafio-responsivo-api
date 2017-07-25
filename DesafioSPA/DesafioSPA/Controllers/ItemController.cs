using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioSPA.Models;

#region ItemController
namespace DesafioSPA.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly ItemContext _context;

        public ItemController(ItemContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new Item { Label = "Item1", Url= "www" });
                _context.SaveChanges();
            }
        }

        #region getAllCategories
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return _context.TodoItems.ToList();
        }
        #endregion
        #region getCategory
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetItemById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #endregion
        #region createCategory
        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategory", new { id = item.Id }, item);
        }
        #endregion
        #region updateCategory
        [HttpPut("{id}")]
        public IActionResult UpdateItem(long id, [FromBody] Item item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Label = item.Label;
            todo.Url = item.Url;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion
        #region deleteCategory
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(long id)
        {
            var todo = _context.TodoItems.First(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
        #endregion
    }
}
#endregion