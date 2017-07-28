using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using DesafioSPA.Models;
using DesafioSPA.IBLL;
using DesafioSPA.Controllers;
using System.Collections.Generic;

namespace DesafioSPAXUnitTest
{
    public class ItemValidatorTest
    {
        private ItemContext _itemContext;
        private Item _item;
        private List<Item> listItems = new List<Item>();

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
            //single item 
            _item = new Item { Label = "Categoria", Url = "#/categoria",  SubItm = new SubItem { Label = "subcategoria", Url = "#/categoria/subcategoria" } };

            //list of items 
            listItems.Add(new Item { Label = "Animais e acessórios", Url = "#/animais-e-acessorios",  SubItm = new SubItem { Label = "Cachorros", Url = "#/animais-e-acessorios/cachorros" } });
            listItems.Add(new Item { Label = "Animais e acessórios", Url = "#/animais-e-acessorios",  SubItm = new SubItem { Label = "Outros animais", Url = "#/animais-e-acessorios/outros-animais" } });
            listItems.Add(new Item { Label = "Bebês e crianças", Url = "#/bebes-e-criancas", SubItm = new SubItem { Label = "Instrumentos musicais", Url = "#/musicas-e-hobbies/instrumentos-musicais" } });
    
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

            Assert.Equal(1, resultItem.Id);
        }

        [Fact]
        public void save_several_items_test()
        {
            var itemRepository = new ItemRepository(_itemContext);

            listItems.ForEach(x => itemRepository.CreateItem(x));
            var a = itemRepository.GetItemById(2);

            Assert.Equal("Animais e acessórios",itemRepository.GetItemById(3).Label);
            Assert.Equal("Animais e acessórios", itemRepository.GetItemById(4).Label);
            Assert.Equal("Bebês e crianças", itemRepository.GetItemById(5).Label);
       
        }

        [Fact]
        public void delete_item_test()
        {
            var itemRepository = new ItemRepository(_itemContext);
            itemRepository.DeleteItem(1);
            
            Assert.Null(itemRepository.GetItemById(1));
        }

        [Fact]
        public void item_is_updating_test()
        {
            var itemRepository = new ItemRepository(_itemContext);
            var resultItem = itemRepository.GetItemById(1);
            resultItem.Label = "Updating Label";

            itemRepository.UpdateItem(1, resultItem);

            Assert.Contains("Updating Label", itemRepository.GetItemById(1).Label);

        }

    }
}
