namespace arkano.logic.common.Factories
{
    using arkano.common.configuration;
    using arkano.common.interfaces;
    using arkano.logic.interfaces;

    public class LogicFactory<TModel, TLogic> : ILogicFactory<TModel>
        where TModel: class, IModel
        where TLogic : ILogic<TModel>, new()
    {
        public ILogic<TModel> GetLogic(ArkanoContext context)
        {
            var logic = new TLogic();
            logic.SetContext(context);
            return logic;
        }
    }
}
