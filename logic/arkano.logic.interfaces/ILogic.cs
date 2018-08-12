namespace arkano.logic.interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using arkano.common.configuration;
    using arkano.common.domain;
    using arkano.common.interfaces;

    public interface ILogic<TModel>
        where TModel : class, IModel
    {
        ArkanoContext Context { get; }

        ILogicFactory<DummyTestModel> FactoryDummyTestModel { get; }

        ILogicFactory<OtroDummyTestModel> FactoryOtroDummyTestModel { get; }

        void SetContext(ArkanoContext context);

        Task<IList<TModel>> All();

        Task<TModel> Get(int id);

        Task New(TModel model);

        Task Update(TModel model);

        Task Delete(int id);
    }
}
