namespace arkano.api.Controllers.DummyTest
{
    using arkano.common.domain;
    using arkano.logic.common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class StudentsController : Base.BaseController<Student, StudentLogic>
    {
        // Extend controller here
        public StudentsController(ILogger<object> logger) : base(logger)
        {
        }
    }
}