using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;

namespace EndPointLibs.Repositories
{
    internal class CfHttpHeaderRepository : RepositoryBase<CfHttpHeader>, ICfHttpHeaderRepository
    {
        public CfHttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}