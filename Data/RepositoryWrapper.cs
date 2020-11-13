using Data.Repositories;
using Libs.Repositories;

namespace Data
{
    internal class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationContext _repositoryContext;

        private CfHttpHeaderRepository _cfHttpHeader;
        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsClientAuthRepository _tlsClientAuth;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        public ICfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository(_repositoryContext);
        public IHttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public IHttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext);
        public ITlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository(_repositoryContext);
        public ITlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_repositoryContext);

        public RepositoryWrapper(ApplicationContext context) => _repositoryContext = context;
    }
}