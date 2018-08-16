namespace arkano.logic.interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
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

        Task<IQueryable<TModel>> All();

        Task<TModel> FindByKey(TModel pksModel);

        Task<TModel> FindByKey(params object[] prms);

        Task<IQueryable<TModel>> Where(Expression<Func<TModel, bool>> predicate);

        Task<TModel> FirstOrDefault(Expression<Func<TModel, bool>> predicate);

        Task<TModel> LastOrDefault(Expression<Func<TModel, int>> keySelector, Expression<Func<TModel, bool>> predicate);

        Task<TModel> SingleOrDefault(Expression<Func<TModel, bool>> predicate);

        Task New(TModel model);

        Task Update(TModel model);

        Task Delete(TModel model);

        Task Delete(params object[] prms);
    }
}
