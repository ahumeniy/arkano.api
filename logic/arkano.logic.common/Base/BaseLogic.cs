namespace arkano.logic.common.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using arkano.common.configuration;
    using arkano.common.domain;
    using arkano.common.interfaces;
    using arkano.data.interfaces;
    using arkano.logic.common.Factories;
    using arkano.logic.interfaces;

    public abstract class BaseLogic<TModel> : ILogic<TModel>
        where TModel : class, IModel
    {
        public BaseLogic(IRepository<TModel> repository)
        {
            this.Repository = repository;
            this.FactoryDummyTestModel = new LogicFactory<DummyTestModel, DummyTestLogic>();
            this.FactoryOtroDummyTestModel = new LogicFactory<OtroDummyTestModel, OtroDummyTestLogic>();
        }

        public ArkanoContext Context { get; private set; }

        public ILogicFactory<DummyTestModel> FactoryDummyTestModel { get; private set; }

        public ILogicFactory<OtroDummyTestModel> FactoryOtroDummyTestModel { get; private set; }

        protected IRepository<TModel> Repository { get; }

        public virtual Task<IList<TModel>> All()
        {
            return Task.FromResult((IList<TModel>)this.Repository.All().Result.ToList());
        }

        public virtual Task Delete(TModel model)
        {
            var result = this.Repository.Delete(model);

            // TODO: see if it's ok call savechanges here. Don't call it directly on repo allow to call many times this without saving yet.
            this.Repository.SaveChanges();
            return result;
        }

        public virtual Task Delete(params object[] prms)
        {
            var result = this.Repository.Delete(prms);

            // TODO: see if it's ok call savechanges here. Don't call it directly on repo allow to call many times this without saving yet.
            this.Repository.SaveChanges();
            return result;
        }

        public virtual Task<TModel> FindByKey(TModel pksModel)
        {
            return this.Repository.FindByKey(pksModel);
        }

        public virtual Task<TModel> FindByKey(params object[] prms)
        {
            return this.Repository.FindByKey(prms);
        }

        public virtual Task<TModel> FirstOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            return this.Repository.FirstOrDefault(predicate);
        }

        public virtual Task<TModel> LastOrDefault(Expression<Func<TModel, int>> keySelector, Expression<Func<TModel, bool>> predicate)
        {
            return this.Repository.LastOrDefault(keySelector, predicate);
        }

        public virtual Task New(TModel model)
        {
            var result = this.Repository.New(model);

            // TODO: see if it's ok call savechanges here. Don't call it directly on repo allow to call many times this without saving yet.
            this.Repository.SaveChanges();
            return result;
        }

        public void SetContext(ArkanoContext context)
        {
            this.Context = context;
        }

        public virtual Task<TModel> SingleOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            return this.Repository.SingleOrDefault(predicate);
        }

        public virtual Task Update(TModel model)
        {
            var result = this.Repository.Update(model);

            // TODO: see if it's ok call savechanges here. Don't call it directly on repo allow to call many times this without saving yet.
            this.Repository.SaveChanges();
            return result;
        }

        public virtual Task<IList<TModel>> Where(Expression<Func<TModel, bool>> predicate)
        {
            return Task.FromResult((IList<TModel>)this.Repository.Where(predicate).Result.ToList());
        }
    }
}
