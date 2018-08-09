﻿namespace arkano.logic.interfaces
{
    using arkano.common.configuration;
    using arkano.common.interfaces;
    using System.Collections.Generic;

    public interface ILogic<TModel> where TModel : class, IModel
    {
        void SetContext(ArkanoContext context);
        IList<TModel> All();
        TModel Get(int id);
        void New(TModel model);
        void Update(TModel model);
        void Delete(int id);

    }
}
