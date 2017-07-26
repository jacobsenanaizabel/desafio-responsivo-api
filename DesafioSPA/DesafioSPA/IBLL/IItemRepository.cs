using DesafioSPA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSPA.IBLL
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(long id);
        void CreateItem([FromBody] Item item);
        void UpdateItem(long id, [FromBody] Item item);
        void DeleteItem(long id);

    }
}
