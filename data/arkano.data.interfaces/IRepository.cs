namespace arkano.data.interfaces
{
    using arkano.common.interfaces;

    public interface IRepository<TModel> where TModel : class, IModel
    {
    }
}
