using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOAT_TweetHub.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GOAT_TweetHub.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {

    }

    public abstract class CRUDController : BaseController
    {
        protected BaseService _service;
        
        // GET: api/Base
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Base/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Base
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
