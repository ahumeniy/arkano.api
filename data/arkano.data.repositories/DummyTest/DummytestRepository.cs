namespace arkano.data.repositories.DummyTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.daccess.Context;
    using arkano.data.repositories.Base;

    public class DummyTestRepository : BaseRepository<DummyTestModel>
    {
        public Task<IQueryable<DummyTestModel>> AllSpecial()
        {
            return Task.FromResult(this.modelContext.Where(x => x.Id > 5000));
        }

        public Task<IQueryable<DummyTestModel>> AllSpecialOther()
        {
            return Task.FromResult(this.modelContext.Where(x => x.Id > 5000));
        }
    }
}
