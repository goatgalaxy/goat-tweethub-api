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

        public IEnumerable<TModel> Find()
        {
            return _dao.Find();
        }

        public TModel Find(int id)
        {
            return _dao.Find(id);
        }

        public TModel Insert(TModel obj)
        {
            return _dao.Insert(obj);
        }

        public TModel Remove(int id)
        {
            return _dao.Remove(id);
        }

        public TModel Edit(TModel obj, int id)
        {
            return _dao.Edit(obj, id);
        }
    }
}
