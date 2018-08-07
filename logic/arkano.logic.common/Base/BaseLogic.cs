using arkano.common.interfaces;
using arkano.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace arkano.logic.common.Base
{
    public class BaseLogic<TModel> : ILogic<TModel> where TModel : class, IModel
    {
        public virtual IList<TModel> All()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void New(TModel model)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
