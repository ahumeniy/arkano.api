namespace arkano.logic.common
{
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.repositories.Base;
    using arkano.data.repositories.DummyTest;
    using arkano.logic.common.Base;
    using arkano.logic.interfaces;

    public class CourseLogic : BaseLogic<Course>
    {
        public CourseLogic() : base(new CourseRepository())
        {
        }
    }
}
