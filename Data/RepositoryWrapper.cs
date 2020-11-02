using Data.Repositories;
using Data.Repositories.Interfaces;

namespace Data
{
    public class RepositoryWrapper
    {
        private readonly ApplicationContext _repositoryContext;

        private CfHttpHeaderRepository _cfHttpHeader;
        private HttpHeaderRepository _httpHeader;
        private HttpRequestRepository _httpRequest;
        private TlsClientAuthRepository _tlsClientAuth;
        private TlsExportedAuthenticatorRepository _tlsExportedAuthenticator;

        public CfHttpHeaderRepository CfHttpHeader => _cfHttpHeader ??= new CfHttpHeaderRepository(_repositoryContext);
        public HttpHeaderRepository HttpHeader => _httpHeader ??= new HttpHeaderRepository(_repositoryContext);
        public HttpRequestRepository HttpRequest => _httpRequest ??= new HttpRequestRepository(_repositoryContext);
        public TlsClientAuthRepository TlsClientAuth => _tlsClientAuth ??= new TlsClientAuthRepository(_repositoryContext);
        public TlsExportedAuthenticatorRepository TlsExportedAuthenticator => _tlsExportedAuthenticator ??= new TlsExportedAuthenticatorRepository(_repositoryContext);

        public RepositoryWrapper(ApplicationContext context) => _repositoryContext = context;
    }
}