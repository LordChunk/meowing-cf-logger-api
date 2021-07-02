using Data.Repositories.Common;
using Interface.Data;
using Interface.Models;

namespace Data.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}