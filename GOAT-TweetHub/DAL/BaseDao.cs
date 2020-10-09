using GOAT_TweetHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GOAT_TweetHub.DAL
{
    public abstract class BaseDao<TModel> where TModel : BaseModel
    {
        protected abstract DbSet<TModel> _dbSet { get; }

        protected MainContext Context = ContextKeeper.Context;

        public BaseDao()
        {
        }

        public IEnumerable<TModel> Find()
        {
            return _dbSet.ToList();
        }

        public TModel Find(int id)
        {
            return _dbSet.FirstOrDefault(o => o.Id == id);
        }

        public TModel Insert(TModel obj)
        {
            TModel addedObj = _dbSet.Add(obj);
            Context.SaveChanges();
            return addedObj;
        }

        public TModel Remove(int id)
        {
            TModel removedObj = _dbSet.Remove(Find(id));
            Context.SaveChanges();
            return removedObj;
        }

        public TModel Remove(TModel obj)
        {
            TModel removedObj = _dbSet.Remove(obj);
            Context.SaveChanges();
            return removedObj;
        }

        public TModel Edit(TModel obj, int id)
        {
            DbEntityEntry<TModel> entry = Context.Entry(Find(id));
            obj.Id = id;
            entry.CurrentValues.SetValues(obj);
            entry.State = EntityState.Modified;
            Context.SaveChanges();
            entry.Reload();
            return entry.Entity;
        }

        public TModel EditPartial(TModel obj, int id)
        {
            DbEntityEntry<TModel> entry = Context.Entry(Find(id));
            obj.Id = id;
            foreach (string property in entry.CurrentValues.PropertyNames)
            {
                if((entry.CurrentValues[property] == null && 
                        (!obj.GetType().GetProperty(property).GetValue(obj)?.Equals(null) ?? false)) ||
                    (entry.CurrentValues[property] != null) 
                        && (!obj.GetType().GetProperty(property)?.Equals(null) ?? false) 
                        && (!obj.GetType().GetProperty(property).GetValue(obj)?.Equals(entry.CurrentValues[property]) ?? false))
                {
                    entry.CurrentValues[property] = obj.GetType().GetProperty(property).GetValue(obj);
                }
            }
            entry.State = EntityState.Modified;
            Context.SaveChanges();
            entry.Reload();
            return entry.Entity;
        }

    }
}
