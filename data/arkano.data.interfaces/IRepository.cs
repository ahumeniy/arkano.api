namespace arkano.data.interfaces
{
    using arkano.common.interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TModel> where TModel : class, IModel
    {
        Task<IList<TModel>> All();
        Task<TModel> Get(int id);
        Task New(TModel model);
        Task Update(TModel model);
        Task Delete(int id);
    }
}
