using Data.Models;
using Data.Repositories.Common;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>
    {
        public CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}