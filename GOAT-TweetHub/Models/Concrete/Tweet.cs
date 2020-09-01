using GOAT_TweetHub.Enums;
using GOAT_TweetHub.Models;

namespace GOAT_TweetHub
{
    public class Tweet : BaseModel
    {
        public string Message { get; set; }

        public string Region { get; set; }

        public TweetStatus Status { get; set; } = TweetStatus.InQueue;

        public Sentiment? Sentiment { get; set; }
    }
}
