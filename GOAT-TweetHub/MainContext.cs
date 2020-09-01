
using System.Data.Entity;

namespace GOAT_TweetHub
{
    public class MainContext : DbContext
    {
        public MainContext() : base("Data Source=.\\SQLEXPRESS;Initial Catalog=Test;MultipleActiveResultSets=true;user=sa;password=123")
        {
        }
        public DbSet<Tweet> Tweets { get; set; }
    }

    public static class ContextKeeper
    {
        public static readonly MainContext Context = new MainContext();
    }
}
