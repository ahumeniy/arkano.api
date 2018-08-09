using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arkano.api.Models.Interfaces;
using arkano.common.configuration;
using arkano.common.interfaces;
using arkano.logic.common.Factories;
using arkano.logic.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace arkano.api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel, TBLogic> : ControllerBase
        where TModel : class, IModel
        where TBLogic : ILogic<TModel>, new()
    {
        public BaseController(ILogger<object> logger)
        {
            this.Logger = logger;
            this.LogicFactory = new LogicFactory<TModel, TBLogic>();
        }

        protected ILogger<object> Logger { get; }

        protected ILogicFactory<TModel> LogicFactory { get; }

        // GET: api/Base
        [HttpGet]
        public IList<TModel> Get()
        {
            return this.GetLogic().All();
        }

        // GET: api/Base/5
        [HttpGet("{id}", Name = "Get")]
        public TModel Get(int id)
        {
            return this.GetLogic().Get(id);
        }

        // POST: api/Base
        [HttpPost]
        public void Post([FromBody] TModel value)
        {
            this.GetLogic().New(value);
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TModel value)
        {
            this.GetLogic().Update(value);
        }

        // PATCH: api/Base/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] TModel value)
        {
            this.GetLogic().Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.GetLogic().Delete(id);
        }

        protected ArkanoContext GetContext()
        {
            var tenant = this.HttpContext.Features.Get<ITenantFeature>();
            return new ArkanoContext(tenant.Tenant);
        }

        protected ILogic<TModel> GetLogic()
        {
            return this.LogicFactory.GetLogic(this.GetContext());
        }
    }
}
