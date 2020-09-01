using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GOAT_TweetHub.DAL
{
    public class TweetDao : BaseDao<Tweet>
    {
        protected override DbSet<Tweet> _dbSet => Context.Tweets;
    }
}
