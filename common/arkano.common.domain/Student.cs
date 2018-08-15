namespace arkano.common.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using arkano.common.interfaces;

    public class Student : IModel
    {
        public int Id { get; set; }

        public string CI { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public DateTime BornDate { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public int? BestFriendId { get; set; }

        [ForeignKey("BestFriendId")]        
        public virtual Student BestFriend { get; set; }
    }
}
