﻿namespace arkano.api.Controllers.Base
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using arkano.api.Models.Interfaces;
    using arkano.common.configuration;
    using arkano.common.interfaces;
    using arkano.logic.common.Factories;
    using arkano.logic.interfaces;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [EnableQuery]
    [ApiController]
    public abstract class BaseController<TModel, TBLogic> : ODataController
        where TModel : class, IModel, new()
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
        public Task<IQueryable<TModel>> Get()
        {
            return this.GetLogic().All();
        }

        // [HttpGet]
        // [ActionName("GetLala")]
        // public Task<TModel> GetLala()
        // {
        //    return Task.FromResult(new TModel());// this.GetLogic().All();
        // }        

        // TODO: See why with this method routes addresses Get() and Get(int id) as same
        //// GET: api/Base/5
        // [HttpGet("{id}", Name = "Get")]
        // public Task<TModel> Get(int id)
        // {
        //    return this.GetLogic().Get(id);
        // }

        // POST: api/Base
        [HttpPost]
        public Task Post([FromBody] TModel value)
        {
            return this.GetLogic().New(value);
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] TModel value)
        {
            return this.GetLogic().Update(value);
        }

        // PATCH: api/Base/5
        [HttpPatch("{id}")]
        public Task Patch(int id, [FromBody] TModel value)
        {
            return this.GetLogic().Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return this.GetLogic().Delete(id);
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
