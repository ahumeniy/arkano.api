namespace arkano.logic.interfaces.Validations
{
    using arkano.common.interfaces;

    public interface IValidation<TModel>
        where TModel : class, IModel
    {
    }
}
