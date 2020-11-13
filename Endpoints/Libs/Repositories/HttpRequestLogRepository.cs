using Data;
using EndPointLibs.Repositories.Common;
using Libs.Models;
using Libs.Repositories;

namespace EndPointLibs.Repositories
{
    internal class HttpRequestLogRepository : RepositoryBase<HttpRequestLog>, IHttpRequestLogRepository
    {
        public HttpRequestLogRepository(ApplicationContext context) : base(context) {}
    }
}