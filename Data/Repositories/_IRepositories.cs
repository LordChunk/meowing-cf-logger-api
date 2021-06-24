using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public interface IHttpHeaderRepository : IRepository<HttpHeader> { }
    public interface IHttpRequestLogRepository : IRepository<HttpRequestLog> { }

    public interface IHttpRequestRepository : IRepository<HttpRequest>
    {
        public Task<List<HttpRequest>> GetRecentRequests(int count);
    }
    public interface ITlsExportedAuthenticatorRepository : IRepository<TlsExportedAuthenticator> { }
    public interface IRequestUrlRepository : IRepository<RequestUrl> { }
}