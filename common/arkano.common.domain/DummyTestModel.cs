using arkano.common.interfaces;
using System;

namespace arkano.common.domain
{
    public class DummyTestModel : IModel
    {
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
