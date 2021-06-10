using Data.Models;
using Data.Repositories.Common;

namespace Data.Repositories
{
    public interface ICfHttpHeaderRepository : IRepository<CfHttpHeader> { }
    public interface IHttpHeaderRepository : IRepository<HttpHeader> { }
    public interface IHttpRequestLogRepository : IRepository<HttpRequestLog> { }
    public interface IHttpRequestRepository : IRepository<HttpRequest> { }
    public interface ITlsClientAuthRepository : IRepository<TlsClientAuth> { }
    public interface ITlsExportedAuthenticatorRepository : IRepository<TlsExportedAuthenticator> { }
    public interface IRequestUrlRepository : IRepository<RequestUrl> { }
}