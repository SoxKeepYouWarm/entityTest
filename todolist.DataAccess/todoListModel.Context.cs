﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace todolist.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class todolistEntities : DbContext
    {
        public todolistEntities()
            : base("name=todolistEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<list> lists { get; set; }
    
        public virtual ObjectResult<getItems_Result> getItems()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getItems_Result>("getItems");
        }
    
        public virtual ObjectResult<getItemsComplete_Result> getItemsComplete()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getItemsComplete_Result>("getItemsComplete");
        }
    
        public virtual ObjectResult<getItemsIncomplete_Result> getItemsIncomplete()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getItemsIncomplete_Result>("getItemsIncomplete");
        }
    
        public virtual int insertItem(string text, Nullable<bool> isComplete)
        {
            var textParameter = text != null ?
                new ObjectParameter("text", text) :
                new ObjectParameter("text", typeof(string));
    
            var isCompleteParameter = isComplete.HasValue ?
                new ObjectParameter("isComplete", isComplete) :
                new ObjectParameter("isComplete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertItem", textParameter, isCompleteParameter);
        }
    
        public virtual int removeItem(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeItem", idParameter);
        }
    
        public virtual int updateItemCompleteness(Nullable<int> id, Nullable<bool> isComplete)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var isCompleteParameter = isComplete.HasValue ?
                new ObjectParameter("isComplete", isComplete) :
                new ObjectParameter("isComplete", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateItemCompleteness", idParameter, isCompleteParameter);
        }
    
        public virtual int updateItemText(Nullable<int> id, string text)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var textParameter = text != null ?
                new ObjectParameter("text", text) :
                new ObjectParameter("text", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateItemText", idParameter, textParameter);
        }
    }
}
