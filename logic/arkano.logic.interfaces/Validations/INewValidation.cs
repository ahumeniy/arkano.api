namespace arkano.logic.interfaces.Validations
{
    using System.Threading.Tasks;
    using arkano.common.interfaces;

    public interface INewValidation<TModel> : IValidation<TModel>
        where TModel : class, IModel
    {
        Task Validate(TModel model, ILogic<TModel> logic);
    }
}
