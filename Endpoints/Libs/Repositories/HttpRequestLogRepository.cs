using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;

namespace EndPointLibs.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context) {}
    }
}