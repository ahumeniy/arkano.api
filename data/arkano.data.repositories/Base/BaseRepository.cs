namespace arkano.data.repositories.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using arkano.common.interfaces;
    using arkano.data.daccess.Context;
    using arkano.data.interfaces;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseRepository<TModel> : IRepository<TModel>, IDisposable
        where TModel : class, IModel
    {
        public BaseRepository()
        {
            this.context = new ArkanoEfContext();
            this.modelContext = this.context.Set<TModel>();
        }

        public BaseRepository(ArkanoEfContext context)
        {
            this.context = context;
            this.modelContext = this.context.Set<TModel>();
        }

        protected DbSet<TModel> modelContext { get; }

        protected ArkanoEfContext context { get; }

        public Task<int> SaveChanges()
        {
            return Task.FromResult(this.context.SaveChanges());
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public virtual Task<IQueryable<TModel>> All()
        {
            return Task.FromResult(this.modelContext.AsQueryable());
        }

        public virtual Task<TModel> FindByKey(TModel pksModel)
        {
            return Task.FromResult(this.modelContext.Find(pksModel));
        }

        public virtual Task<TModel> FindByKey(params object[] prms)
        {
            return Task.FromResult(this.modelContext.Find(prms));
        }

        public virtual Task<IQueryable<TModel>> Where(Expression<Func<TModel, bool>> predicate)
        {
            return Task.FromResult(this.modelContext.Where(predicate));
        }

        public virtual Task<TModel> FirstOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            return Task.FromResult(this.modelContext.FirstOrDefault(predicate));
        }

        public virtual Task<TModel> LastOrDefault(Expression<Func<TModel, int>> keySelector, Expression<Func<TModel, bool>> predicate)
        {
            return Task.FromResult(this.modelContext.OrderByDescending(keySelector).FirstOrDefault(predicate));
        }

        public virtual Task<TModel> SingleOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            return Task.FromResult(this.modelContext.SingleOrDefault(predicate));
        }

        public virtual Task New(TModel model)
        {
            this.modelContext.Add(model);

            return Task.CompletedTask;
        }

        public virtual Task Update(TModel model)
        {
            this.context.Attach(model);

            if (this.context.Entry(model).State != EntityState.Detached)
            {
                this.context.Entry(model).State = EntityState.Modified;
            }

            return Task.CompletedTask;
        }

        public virtual Task Delete(TModel model)
        {
            this.context.Attach(model);

            if (this.context.Entry(model).State != EntityState.Detached)
            {
                this.context.Entry(model).State = EntityState.Modified;
            }

            this.modelContext.Remove(model);

            return Task.CompletedTask;
        }

        public virtual Task Delete(params object[] prms)
        {
            TModel model = this.FindByKey(prms).Result;

            if (model != null)
            {
                this.modelContext.Remove(model);
            }

            return Task.CompletedTask;
        }

        // TODO: see if is needed this to can call directly to DataAcces of other Models inside any repo.
        // I think the best way is doing it through the respective Model repo. See GetModelRepo method.
        // protected DbSet<T> GetModelContext<T>()
        //    where T : class, IModel
        // {
        //    return this.context.Set<T>();
        // }
        public TRepo GetModelRepo<T, TRepo>()
            where T : class, IModel
            where TRepo : class, IRepository<T>, IDisposable, new()
        {
            return (TRepo)Activator.CreateInstance(typeof(TRepo), this.context);
        }
    }
}
