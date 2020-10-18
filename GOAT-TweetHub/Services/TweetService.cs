using GOAT_TweetHub.DAL;
using GOAT_TweetHub.Models.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace GOAT_TweetHub.Services
{
    public class TweetService : BaseService<Tweet, TweetDao>
    {
        public override Tweet Insert(Tweet obj)
        {
            Tweet added = base.Insert(obj);
            RestClient client = new RestClient("http://localhost:4100/")
            {
                Timeout = -1
            };
            RestRequest request = new RestRequest(Method.POST)
            {
                AlwaysMultipartFormData = true
            };
            request.AddParameter("Action", "SendMessage");
            request.AddParameter("QueueUrl", "http://localhost:4100/queue/local-queue1");
            MessageBody message = new MessageBody(added.Id, added.Message);
            request.AddParameter("MessageBody", JsonConvert.SerializeObject(message));
            request.AddParameter("Version", "2012-11-05");
            IRestResponse response = client.Execute(request);

            if(!response.IsSuccessful)
            {
                Remove(added.Id);
                throw new Exception("Couldn't enqueue message");
            }

            return added;
        }
    }
}
