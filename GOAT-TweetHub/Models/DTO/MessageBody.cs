using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOAT_TweetHub.Models.DTO
{
    public class MessageBody
    {
        public MessageBody(int id, string message)
        {
            this.id = id;
            this.message = message;
        }

        public int id { get; set; }
        public string message { get; set; }
    }
}
