using GOAT_TweetHub.DAL;
using GOAT_TweetHub.Models;
using System;
using System.Collections.Generic;

namespace GOAT_TweetHub.Services
{
    public abstract class BaseService<TModel, TDao> where TModel : BaseModel where TDao : BaseDao<TModel>
    {
        protected readonly BaseDao<TModel> _dao;

        public BaseService()
        {
            _dao = Activator.CreateInstance<TDao>();
        }

        public virtual IEnumerable<TModel> Find()
        {
            return _dao.Find();
        }

        public virtual TModel Find(int id)
        {
            return _dao.Find(id);
        }

        public virtual TModel Insert(TModel obj)
        {
            return _dao.Insert(obj);
        }

        public virtual TModel Remove(int id)
        {
            return _dao.Remove(id);
        }

        public virtual TModel Edit(TModel obj, int id)
        {
            return _dao.Edit(obj, id);
        }

        public virtual TModel EditPartial(TModel obj, int id)
        {
            return _dao.EditPartial(obj, id);
        }
    }
}
