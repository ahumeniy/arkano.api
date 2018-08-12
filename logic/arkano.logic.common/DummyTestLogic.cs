using arkano.common.domain;
using arkano.data.interfaces;
using arkano.data.repositories.Base;
using arkano.logic.common.Base;
using arkano.logic.common.Factories;
using arkano.logic.interfaces;
using System;
using System.Threading.Tasks;

namespace arkano.logic.common
{
    public class DummyTestLogic : BaseLogic<DummyTestModel>
    {
        public DummyTestLogic() : base(new BaseRepository<DummyTestModel>())
        {
        }

        public override Task<DummyTestModel> Get(int id)
        {
            return Task.FromResult(new DummyTestModel());
        }

        public override Task New(DummyTestModel model)
        {
            ILogic<OtroDummyTestModel> logic2 = this.factoryOtroDummyTestModel.GetLogic(this.Context);
            return base.New(model);
        }
    }
}
