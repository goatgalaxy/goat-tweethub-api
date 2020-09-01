using Amazon.S3;
using Amazon.S3.Model;
using GOAT_TweetHub.DAL;
using GOAT_TweetHub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GOAT_TweetHub.Controllers
{
    public class TweetController : CRUDController<Tweet, TweetService, TweetDao>
    {
        public IAmazonS3 S3Client { get; set; }

        public TweetController(IAmazonS3 s3Client)
        {
            S3Client = s3Client;
        }

        [HttpPost]
        public override ActionResult<Tweet> Post([FromBody] Tweet obj)
        {
            ActionResult<Tweet> response = base.Post(obj);
            if (response.GetType() == typeof(OkObjectResult))
            {
                SendSNS();
            }

            return response;
        }

        public async void SendSNS()
        {
            ListBucketsResponse buckets = await MyListBucketsAsync(S3Client).ConfigureAwait(false);

            string bucketName = "";

            // Call the API method directly
            try
            {
                PutBucketResponse createResponse = await S3Client.PutBucketAsync(bucketName);
            }
            catch (Exception e)
            {
            }
        }

        // Async method to get a list of Amazon S3 buckets.
        private static async Task<ListBucketsResponse> MyListBucketsAsync(IAmazonS3 s3Client)
        {
            return await s3Client.ListBucketsAsync();
        }

    }

}
