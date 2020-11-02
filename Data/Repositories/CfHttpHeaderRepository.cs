using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>
    {
        public CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}