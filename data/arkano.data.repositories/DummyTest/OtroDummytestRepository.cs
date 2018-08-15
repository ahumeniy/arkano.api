namespace arkano.data.repositories.DummyTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using arkano.common.domain;
    using arkano.data.repositories.Base;

    public class OtroDummyTestRepository : BaseRepository<OtroDummyTestModel>
    {
        public Task<IQueryable<OtroDummyTestModel>> AllCustom()
        {
            return Task.FromResult(this.modelContext.Where(x => x.Name.Contains("custom")));
        }
    }
}
