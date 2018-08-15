namespace arkano.api.Controllers.DummyTest
{
    using arkano.common.domain;
    using arkano.logic.common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CoursesController : Base.BaseController<Course, CourseLogic>
    {
        // Extend controller here
        public CoursesController(ILogger<object> logger) : base(logger)
        {
        }
    }
}