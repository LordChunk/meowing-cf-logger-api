using Data.Models;

namespace Data.Repositories.Interfaces
{
    public interface ICfHttpHeaderRepository : IRepositoryBase<CfHttpHeader> {}
    public interface IHttpHeaderRepository : IRepositoryBase<HttpHeader> {}
    public interface IHttpRequestRepository : IRepositoryBase<HttpRequest> {}
    public interface ITlsClientAuthRepository : IRepositoryBase<TlsClientAuth> {}
    public interface ITlsExportedAuthenticatorRepository : IRepositoryBase<TlsExportedAuthenticator> {}
}