namespace arkano.logic.interfaces
{
    using arkano.common.configuration;
    using arkano.common.domain;
    using arkano.common.interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogic<TModel>
        where TModel : class, IModel
    {
        ArkanoContext Context { get; }
        void SetContext(ArkanoContext context);
        Task<IList<TModel>> All();
        Task<TModel> Get(int id);
        Task New(TModel model);
        Task Update(TModel model);
        Task Delete(int id);

        ILogicFactory<DummyTestModel> factoryDmmyTestModel { get; }

        ILogicFactory<OtroDummyTestModel> factoryOtroDummyTestModel { get; }
    }
}
