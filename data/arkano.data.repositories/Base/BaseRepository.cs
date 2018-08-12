using arkano.common.interfaces;
using arkano.data.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace arkano.data.repositories.Base
{
    public class BaseRepository<TModel> : IRepository<TModel>
        where TModel : class, IModel, new()
    {
        public Task<IList<TModel>> All()
        {
            //@TODO: Implement generic code
            return Task.FromResult(new List<TModel> { } as IList<TModel>);
        }

        public Task Delete(int id)
        {
            //@TODO: Implement generic code
            return Task.CompletedTask;
        }

        public Task<TModel> Get(int id)
        {
            return Task.FromResult(new TModel());
        }

        public Task New(TModel model)
        {
            return Task.CompletedTask;
        }

        public Task Update(TModel model)
        {
            return Task.CompletedTask;
        }
    }
}
