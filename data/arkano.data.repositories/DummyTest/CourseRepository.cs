namespace arkano.data.repositories.DummyTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.daccess.Context;
    using arkano.data.repositories.Base;

    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository()
        {
        }

        // TODO: See if there is other way to do that.
        // Needed to use the same context when working with differents repos
        public CourseRepository(ArkanoEfContext context)
            : base(context)
        {
        }

        public override Task New(Course model)
        {
            // Here is how someone could get other repo instance using the same EfContext
            this.GetModelRepo<Student, StudentRepository>().DoLalaStudent();
            return base.New(model);
        }
    }
}
