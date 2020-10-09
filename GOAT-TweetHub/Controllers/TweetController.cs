using GOAT_TweetHub.DAL;
using GOAT_TweetHub.Services;

namespace GOAT_TweetHub.Controllers
{
    public class TweetController : CRUDController<Tweet, TweetService, TweetDao>
    {
    }

}
