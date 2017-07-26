using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioSPA.Models;
using DesafioSPA.IBLL;

#region ItemController
namespace DesafioSPA.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        
        #region getAllCategories
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return itemRepository.GetAllItems();
        }
        #endregion

        #region getCategory
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetItemById(long id)
        {
            var item = itemRepository.GetItemById(id);
            return new ObjectResult(item);
        }
        #endregion
        #region createCategory
        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            if (item == null)
                return BadRequest();

            itemRepository.CreateItem(item);

            return CreatedAtRoute("GetCategory", new { id = item.Id }, item);
        }
        #endregion
        
        #region updateCategory
        [HttpPut("{id}")]
        public IActionResult UpdateItem(long id, [FromBody] Item item)
        {
            if (item == null || item.Id != id)
                return BadRequest();

            itemRepository.UpdateItem(id, item);
            return new NoContentResult();
        }
        #endregion
        #region deleteCategory
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(long id)
        {
            itemRepository.DeleteItem(id);
            return new NoContentResult();
        }
        #endregion
    }
}
#endregion