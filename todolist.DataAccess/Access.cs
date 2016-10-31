using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist.DataAccess
{
    public class Access
    {

        private todolistEntities entities;

        public Access()
        {
            this.entities = new todolistEntities();
        }

        public int insertItem(string text, bool complete)
        {
            int rows = entities.insertItem(text, complete);
            entities.SaveChanges();
            return rows;
            
        }

        public void updateItemText(int id, string text)
        {
            entities.updateItemText(id, text);
            entities.SaveChanges();
        }

        public void updateItemCompleteness(int id, bool isComplete)
        {
            entities.updateItemCompleteness(id, isComplete);
            entities.SaveChanges();
        }

        public void removeItem(int id)
        {
            entities.removeItem(id);
            entities.SaveChanges();
        }

        public List<getItems_Result> getItems()
        {
            return entities.getItems().ToList();
            
        }

        public List<getItemsComplete_Result> getItemsComplete()
        {
            return entities.getItemsComplete().ToList();

        }

        public List<getItemsIncomplete_Result> getItemsIncomplete()
        {
            return entities.getItemsIncomplete().ToList();

        }

    }
}
