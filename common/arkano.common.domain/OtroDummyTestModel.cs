namespace arkano.common.domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using arkano.common.interfaces;

    public class OtroDummyTestModel : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
