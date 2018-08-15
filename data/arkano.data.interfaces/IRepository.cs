namespace arkano.data.interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using arkano.common.interfaces;

    public interface IRepository<TModel> : IDisposable
        where TModel : class, IModel
    {
        Task<int> SaveChanges();

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

        TRepo GetModelRepo<T, TRepo>()
           where T : class, IModel
           where TRepo : class, IRepository<T>, IDisposable, new();
    }
}
