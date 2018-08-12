using arkano.logic.interfaces.Validations;
using arkano.common.domain;
using arkano.logic.interfaces;
using System.Threading.Tasks;

namespace arkano.logic.validations
{
    public class NewDummyModelValidation : INewValidation<DummyTestModel>
    {
        Task INewValidation<DummyTestModel>.Validate(DummyTestModel model, ILogic<DummyTestModel> logic)
        {
            return Task.CompletedTask;
        }
    }
}
