using GOAT_TweetHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOAT_TweetHub.Services
{
    public abstract class BaseService
    {
        protected BaseDao _dao;

        public IEnumerable<string> Get()
        {

        }
    }
}
