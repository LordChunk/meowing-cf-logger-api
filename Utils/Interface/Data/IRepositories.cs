using System.Collections.Generic;
using System.Threading.Tasks;
using Interface.Models;

namespace Interface.Data
{
    public interface IHttpHeaderRepository : IRepository<HttpHeader> { }
    public interface IHttpRequestLogRepository : IRepository<HttpRequestLog> { }

    public interface IHttpRequestRepository : IRepository<HttpRequest>
    {
        public Task<List<HttpRequest>> GetRecentRequests(int count);
    }
    public interface IRequestUrlRepository : IRepository<RequestUrl> { }
}