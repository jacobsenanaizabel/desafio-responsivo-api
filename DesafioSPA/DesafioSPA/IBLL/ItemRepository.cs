using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioSPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioSPA.IBLL
{
    public class ItemRepository : IItemRepository
    {
        private ItemContext _context;

        public ItemRepository(ItemContext context)
        {
            this._context = context;

            if (_context.Item.Count() == 0)
            {
                _context.Item.Add(new Item { Label = "Item1", Url = "www" });
                _context.SaveChanges();
            }
            
        }

        public void CreateItem([FromBody] Item item)
        {
            
            _context.Item.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(long id)
        {
            var item = _context.Item.First(t => t.Id == id);
            _context.Item.Remove(item);
            _context.SaveChanges();
        }

        public Item GetItemById(long id)
        {
            return _context.Item.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateItem(long id, [FromBody] Item item)
        {
            var itemUpdate = _context.Item.FirstOrDefault(t => t.Id == id);

            itemUpdate.Label = item.Label;
            itemUpdate.Url = item.Url;

            _context.Item.Update(itemUpdate);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Item.ToList();
        }
    }
}
