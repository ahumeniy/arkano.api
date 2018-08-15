namespace arkano.common.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using arkano.common.interfaces;    

    public class Course : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public virtual ICollection<Student> StudentsIn { get; set; }
    }
}
