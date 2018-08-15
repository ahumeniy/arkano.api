namespace arkano.logic.common
{
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.repositories.Base;
    using arkano.data.repositories.DummyTest;
    using arkano.logic.common.Base;
    using arkano.logic.interfaces;

    public class DummyTestLogic : BaseLogic<DummyTestModel>
    {
        public DummyTestLogic() : base(new DummyTestRepository())
        {
        }

        public override Task New(DummyTestModel model)
        {
            ILogic<OtroDummyTestModel> logic2 = this.FactoryOtroDummyTestModel.GetLogic(this.Context);            
            return base.New(model);
        }
    }
}
