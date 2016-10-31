using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Core.Objects;


using Xunit;
using Xunit.Abstractions;

using todolist.DataAccess;

namespace todoList.Tests
{
    public class Main
    {

        private readonly ITestOutputHelper output;
        private Access access;

        public Main(ITestOutputHelper _output)
        {
            this.output = _output;
            this.access = new Access();
        }

        [Fact]
        public void testInsert()
        {
            List<getItems_Result> items = access.getItems();
            int initialCount = items.Count();

            int rows = access.insertItem("here's a reminder to do something", false);
            items = access.getItems();
            int finalCount = items.Count();

            Assert.Equal(initialCount + 1, finalCount);
            Assert.Equal(rows, 1);

            output.WriteLine("items: " + items.Count().ToString());
            output.WriteLine("rows affected: " + rows);

        }

        [Fact]
        public void testUpdateCompleteness()
        {
            List<getItems_Result> items = access.getItems();

            int id = items.First<getItems_Result>().id;

            access.updateItemCompleteness(id, true);

            items = access.getItems();
            Assert.Equal(items.Where(a => a.id == id).First().isComplete, true);

            output.WriteLine(items.Count().ToString());

        }

        [Fact]
        public void testUpdateText()
        {
            List<getItems_Result> items = access.getItems();
            int id = items.First<getItems_Result>().id;
            access.updateItemCompleteness(id, true);
            items = access.getItems();
            output.WriteLine(items.Count().ToString());

        }

        [Fact]
        public void testRemoveItem()
        {
            List<getItems_Result> items = access.getItems();
            int id = items.First<getItems_Result>().id;
            access.removeItem(id);
            items = access.getItems();
            output.WriteLine(items.Count().ToString());

        }

        [Fact]
        public void testGetItems()
        {
            List<getItems_Result> items = access.getItems();
        }

        [Fact]
        public void testGetItemsComplete()
        {
            List<getItemsComplete_Result> items = access.getItemsComplete();
        }

        [Fact]
        public void testGetItemsIncomplete()
        {
            List<getItemsIncomplete_Result> items = access.getItemsIncomplete();
        }


    }
}
