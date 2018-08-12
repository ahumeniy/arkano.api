namespace arkano.api.Controllers.DummyTest
{
    using arkano.common.domain;
    using arkano.logic.common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class DummyTestController : Base.BaseController<DummyTestModel, DummyTestLogic>
    {
        // Extend controller here
        public DummyTestController(ILogger<object> logger) : base(logger)
        {
        }
    }
}