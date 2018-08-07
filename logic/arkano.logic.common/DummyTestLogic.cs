using arkano.common.domain;
using arkano.logic.common.Base;
using System;

namespace arkano.logic.common
{
    public class DummyTestLogic : BaseLogic<DummyTestModel>
    {
        public override DummyTestModel Get(int id)
        {
            return new DummyTestModel();
        }
    }
}
