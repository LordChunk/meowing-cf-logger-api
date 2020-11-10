using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class HttpRequestRepository : RepositoryBase<HttpRequest>, IHttpRequestRepository
    {
        public HttpRequestRepository(ApplicationContext repositoryContext) : base(repositoryContext) {}
    }
}