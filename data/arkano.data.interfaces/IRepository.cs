namespace arkano.data.interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using arkano.common.interfaces;

    public interface IRepository<TModel> 
        where TModel : class, IModel
    {
        Task<IList<TModel>> All();

        Task<TModel> Get(int id);

        Task New(TModel model);

        Task Update(TModel model);

        Task Delete(int id);
    }
}
