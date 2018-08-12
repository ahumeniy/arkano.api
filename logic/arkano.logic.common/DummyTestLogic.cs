namespace arkano.logic.common
{
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.repositories.Base;
    using arkano.logic.common.Base;
    using arkano.logic.interfaces;

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
            ILogic<OtroDummyTestModel> logic2 = this.FactoryOtroDummyTestModel.GetLogic(this.Context);
            return base.New(model);
        }
    }
}
