namespace arkano.logic.interfaces
{
    using arkano.common.configuration;
    using arkano.common.interfaces;

    public interface ILogicFactory<TModel>
        where TModel : class, IModel
    {
        ILogic<TModel> GetLogic(ArkanoContext context);
    }
}
