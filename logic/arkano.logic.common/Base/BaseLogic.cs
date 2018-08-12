using arkano.common.configuration;
using arkano.common.domain;
using arkano.common.interfaces;
using arkano.data.interfaces;
using arkano.logic.common.Factories;
using arkano.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arkano.logic.common.Base
{
    public class BaseLogic<TModel> : ILogic<TModel> where TModel : class, IModel
    {
        public BaseLogic(IRepository<TModel> repository)
        {
            this.Repository = repository;
            this.factoryDmmyTestModel = new LogicFactory<DummyTestModel, DummyTestLogic>();
            this.factoryOtroDummyTestModel = new LogicFactory<OtroDummyTestModel, OtroDummyTestLogic>();
        }

        public ArkanoContext Context { get; private set; }

        protected IRepository<TModel> Repository { get; }

        public ILogicFactory<DummyTestModel> factoryDmmyTestModel { get; }

        public ILogicFactory<OtroDummyTestModel> factoryOtroDummyTestModel { get; }

        public virtual Task<IList<TModel>> All()
        {
            return this.Repository.All();
        }

        public virtual Task Delete(int id)
        {
            return this.Repository.Delete(id);
        }

        public virtual Task<TModel> Get(int id)
        {
            return this.Repository.Get(id);
        }

        public virtual Task New(TModel model)
        {
            return this.Repository.New(model);
        }

        public virtual Task Update(TModel model)
        {
            return this.Repository.Update(model);
        }

        public void SetContext(ArkanoContext context)
        {
            this.Context = context;
        }
    }
}
