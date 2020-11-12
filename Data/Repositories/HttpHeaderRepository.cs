using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class HttpHeaderRepository : RepositoryBase<HttpHeader>, IHttpHeaderRepository
    {
        public HttpHeaderRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}