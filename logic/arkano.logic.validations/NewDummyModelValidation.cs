namespace arkano.logic.validations
{
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.logic.interfaces;
    using arkano.logic.interfaces.Validations;

    public class NewDummyModelValidation : INewValidation<DummyTestModel>
    {
        Task INewValidation<DummyTestModel>.Validate(DummyTestModel model, ILogic<DummyTestModel> logic)
        {
            return Task.CompletedTask;
        }
    }
}
