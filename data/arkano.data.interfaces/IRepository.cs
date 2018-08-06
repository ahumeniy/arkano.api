namespace arkano.data.interfaces
{
    using arkano.common.interfaces;

    public interface IRepository<T> where T : class, IModel
    {
    }
}
