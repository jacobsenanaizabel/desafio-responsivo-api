using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DesafioSPA.Models;
using DesafioSPA.IBLL;
using DesafioSPA.Controllers;

namespace DesafioSPAXUnitTest
{
    public class ItemValidatorTest
    {
        private ItemContext _itemContext;
        private Item _item;

        public ItemValidatorTest()
        {
            Arrange();
            InitContext();
        }

        public void InitContext()
        {
            var builder = new DbContextOptionsBuilder<ItemContext>().UseInMemoryDatabase();
            var context = new ItemContext(builder.Options);

            context.Item.Add(_item);
            int changed = context.SaveChanges();
            _itemContext = context;

        }

        public void Arrange()
        {
            _item = new Item { Label = "Categoria", Url = "#/categoria", SubItm = new SubItem { Label = "subcategoria", Url = "#/categoria/subcategoria" } };

        }

        [Fact]
        public void Items_cannot_be_empty()
        {
            var itemRepository = new ItemRepository(_itemContext);
            var allItems = itemRepository.GetAllItems();

            Assert.NotNull(allItems);
        }

        [Fact]
        public void getting_first_item()
        {
            var itemRepository = new ItemRepository(_itemContext);
            var resultItem = itemRepository.GetItemById(1);

            Assert.Equal(_item.Id, resultItem.Id);
        }

    }
}
