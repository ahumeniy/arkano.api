using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arkano.common.interfaces;
using arkano.logic.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arkano.api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel, TBLogic> : ControllerBase
        where TModel : class, IModel
        where TBLogic : ILogic<TModel>, new()
    {
        // GET: api/Base
        [HttpGet]
        public IList<TModel> Get()
        {
            return new TBLogic().All();
        }

        // GET: api/Base/5
        [HttpGet("{id}", Name = "Get")]
        public TModel Get(int id)
        {
            return new TBLogic().Get(id);
        }

        // POST: api/Base
        [HttpPost]
        public void Post([FromBody] TModel value)
        {
            new TBLogic().New(value);
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TModel value)
        {
            new TBLogic().Update(value);
        }

        // PATCH: api/Base/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] TModel value)
        {
            new TBLogic().Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new TBLogic().Delete(id);
        }
    }
}
