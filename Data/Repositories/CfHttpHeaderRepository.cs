using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>, ICfHttpHeaderRepository
    {
        public CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}