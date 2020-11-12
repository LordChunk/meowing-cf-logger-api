using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context) {}
    }
}