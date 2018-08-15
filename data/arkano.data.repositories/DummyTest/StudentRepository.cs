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

    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository()
        {
        }

        public StudentRepository(ArkanoEfContext context)
            : base(context)
        {
        }

        public void DoLalaStudent()
        {
            var p = 0;
            p = p + 1;
        }
    }
}
