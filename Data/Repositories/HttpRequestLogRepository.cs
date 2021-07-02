using Data.Repositories.Common;
using Interface.Data;
using Interface.Models;

namespace Data.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context) {}
    }
}