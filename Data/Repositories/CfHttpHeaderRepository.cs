using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>
    {
        internal CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}