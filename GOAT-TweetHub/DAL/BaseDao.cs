using GOAT_TweetHub.Models;
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
    }
}
