using GOAT_TweetHub.DAL;
using GOAT_TweetHub.Models;
using GOAT_TweetHub.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GOAT_TweetHub.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }

    [Route("api/[controller]")]
    public abstract class CRUDController<TModel, TService, TDao> : BaseController where TModel : BaseModel where TService : BaseService<TModel, TDao> where TDao : BaseDao<TModel>
    {
        protected BaseService<TModel, TDao> _service;

        public CRUDController()
        {
            this._service = Activator.CreateInstance<TService>();
        }

        // GET: api/Base
        [HttpGet]
        public virtual ActionResult<TModel> Get()
        {
            try
            {
                return Ok(_service.Find());
            }
            catch(Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }

        // GET: api/Base/5
        [HttpGet("{id}", Name = "Get")]
        public virtual ActionResult<TModel> Get(int id)
        {
            try
            {
                return Ok(_service.Find(id));
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }

        // POST: api/Base
        [HttpPost]
        public virtual ActionResult<TModel> Post([FromBody] TModel obj)
        {
            try
            {
                return Ok(_service.Insert(obj));
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }

        // PUT: api/Base
        [HttpPut("{id}")]
        public virtual ActionResult<TModel> Put([FromBody] TModel value, int id)
        {
            try
            {
                return Ok(_service.Edit(value, id));
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }

        // PUT: api/Base
        [HttpPatch("{id}")]
        public virtual ActionResult<TModel> Patch([FromBody] TModel value, int id)
        {
            try
            {
                return Ok(_service.EditPartial(value, id));
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public virtual ActionResult<TModel> Delete(int id)
        {
            try
            {
                return Ok(_service.Remove(id));
            }
            catch (Exception ex)
            {
#if DEBUG
                return StatusCode(500, ex);
#else
                return StatusCode(500);
#endif
            }
        }
    }
}
