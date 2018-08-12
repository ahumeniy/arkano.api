namespace arkano.logic.interfaces.Validations
{
    using arkano.common.interfaces;
    using System.Threading.Tasks;

    public interface INewValidation<TModel> : IValidation<TModel>
        where TModel : class, IModel
    {
        Task Validate(TModel model, ILogic<TModel> logic);
    }
}
