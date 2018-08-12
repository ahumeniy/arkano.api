using arkano.common.domain;
using arkano.data.interfaces;
using arkano.data.repositories.Base;
using arkano.logic.common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace arkano.logic.common
{
    public class OtroDummyTestLogic : BaseLogic<OtroDummyTestModel>
    {
        public OtroDummyTestLogic() : base(new BaseRepository<OtroDummyTestModel>())
        {
        }
    }
}
