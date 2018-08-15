﻿namespace arkano.logic.common
{
    using arkano.common.domain;
    using arkano.data.repositories.Base;
    using arkano.data.repositories.DummyTest;
    using arkano.logic.common.Base;

    public class OtroDummyTestLogic : BaseLogic<OtroDummyTestModel>
    {
        public OtroDummyTestLogic() : base(new OtroDummyTestRepository())
        {
        }
    }
}
