using GOAT_TweetHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOAT_TweetHub
{
    public class Tweet
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Region { get; set; }

        public TweetStatus Status { get; set; }

        public Sentiment Sentiment { get; set; }
    }
}
